using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Atrato.Commands.ErrorHistoryCommands.Create;
using Atrato.Entities.DTO.ErrorHistory;
using Atrato.Entities.SupportDTO;

namespace Atrato.Api.Middlewares;

public class ErrorHandling : IMiddleware
{
    private readonly ILogger<ErrorHandling> _logger;
    private readonly IErrorHistoryCreateCommand _createCommand;

    public ErrorHandling(ILogger<ErrorHandling> logger, IErrorHistoryCreateCommand createCommand)
    {
        _logger = logger;
        _createCommand = createCommand;
    }

    private const int MaxPayloadLength = 8192;
    private const string MultipartContentType = "multipart/form-data";

    private static readonly string[] SensitiveFields =
        ["code", "token", "refreshToken", "password", "secret", "key"];

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (IsReadablePayload(context.Request))
        {
            context.Request.EnableBuffering();
        }

        try
        {
            await next(context);
        }
        catch (UnauthorizedAccessException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";
            _logger.LogWarning(ex, "Petición sin identidad válida. {Method} {Path}",
                context.Request.Method, context.Request.Path);

            var response = new StandardResult<string>()
            {
                Data = ex.Message,
                Success = false
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (Exception ex)
        {
            var payload = await GetRequestBodyAsync(context.Request);

            var userId = context.User.UserIdOrNull() ?? Guid.Empty;

            var errorHistoryCreateRequest = new ErrorHistoryCreateRequest()
            {
                Message = ex.Message,
                CreatedAt = DateTime.UtcNow,
                Method = context.Request.Method,
                Path = context.Request.Path,
                UserId = userId,
                StackTrace = ex.StackTrace ?? String.Empty,
                Payload = payload
            };

            var doc = await _createCommand.Execute(errorHistoryCreateRequest, userId);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            _logger.LogError(ex, "Middleware error. RequestId: {RequestId}", doc.Id);

            var response = new StandardResult<string>()
            {
                Data = $"Backend error, try again later and/or contact your administrator - RequestId: {doc.Id}",
                Success = false
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }

    private static bool IsReadablePayload(HttpRequest request)
    {
        if (request.ContentLength is null || request.ContentLength == 0)
            return false;

        return request.ContentType is null ||
               !request.ContentType.Contains(MultipartContentType, StringComparison.OrdinalIgnoreCase);
    }

    private static async Task<string> GetRequestBodyAsync(HttpRequest request)
    {
        if (!IsReadablePayload(request))
            return string.Empty;

        try
        {
            request.Body.Position = 0;

            using var reader = new StreamReader(
                request.Body,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true);

            var buffer = new char[MaxPayloadLength];
            var read = await reader.ReadBlockAsync(buffer, 0, MaxPayloadLength);

            request.Body.Position = 0;

            var body = new string(buffer, 0, read);

            if (request.ContentLength > MaxPayloadLength)
            {
                body += "… [truncado]";
            }

            return Redact(body);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    private static string Redact(string payload)
    {
        foreach (var field in SensitiveFields)
        {
            payload = Regex.Replace(
                payload,
                $"(\"{field}\"\\s*:\\s*)\"[^\"]*\"",
                "$1\"XXXXXX\"",
                RegexOptions.IgnoreCase);
        }

        return payload;
    }
}