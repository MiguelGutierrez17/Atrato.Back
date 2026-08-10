using Atrato.Entities.Context;

namespace Atrato.Api.Middlewares;

public class UnitOfWork : IMiddleware
{
    private readonly AtratoContext _context;
    private readonly AtratoAuditContext _auditContext;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(AtratoContext context, AtratoAuditContext auditContext, ILogger<UnitOfWork> logger)
    {
        _context = context;
        _auditContext = auditContext;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            await next(context);

            await transaction.CommitAsync();
        }
        catch
        {
            _context.ChangeTracker.Clear();
            _auditContext.ChangeTracker.Clear();

            throw;
        }

        await SaveAuditAsync(context);
    }

    private async Task SaveAuditAsync(HttpContext context)
    {
        if (!_auditContext.ChangeTracker.HasChanges())
        {
            return;
        }

        try
        {
            await _auditContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "No se pudo guardar la auditoría de {Method} {Path}. El cambio de negocio quedó confirmado sin registro.",
                context.Request.Method,
                context.Request.Path);
        }
    }
}
