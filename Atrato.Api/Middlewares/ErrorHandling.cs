using System.Net;
using System.Text;
using System.Text.Json;
using Atrato.Commands.ErrorHistoryCommands.Create;
using Atrato.Entities.DTO.ErrorHistory;
using Atrato.Entities.SupportDTO;
using Microsoft.IdentityModel.JsonWebTokens;

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

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var payload = await GetRequestBodyAsync(context.Request);
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var userClaim = context.User.FindFirst(JwtRegisteredClaimNames.Sub) ??
                            context.User.FindFirst("id") ?? context.User.FindFirst("nameidentifier");

            Guid? userId = Guid.Empty;

            if (userClaim != null && Guid.TryParse(userClaim.Value, out var parseId))
            {
                userId = parseId;
            }

            var errorHistoryCreateRequest = new ErrorHistoryCreateRequest()
            {
                Message = ex.Message,
                CreatedAt = DateTime.UtcNow,
                Method = context.Request.Method,
                Path = context.Request.Path,
                UserId = userId ?? Guid.Empty,
                StackTrace = ex.StackTrace ?? String.Empty,
                Payload = payload
            };
            
            var doc = await _createCommand.Execute(errorHistoryCreateRequest, userId ?? Guid.Empty);
            
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

    private static async Task<string> GetRequestBodyAsync(HttpRequest request)
    {
        if (request.ContentLength is null || request.ContentLength == 0)
            return string.Empty;

        request.EnableBuffering();

        request.Body.Position = 0;

        using var reader = new StreamReader(
            request.Body,
            Encoding.UTF8,
            detectEncodingFromByteOrderMarks: false,
            leaveOpen: true);

        var body = await reader.ReadToEndAsync();

        request.Body.Position = 0;

        return body;
    }
}