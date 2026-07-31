using Atrato.Commands.EnterpriseAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Enterprise;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.EnterpriseCommands.Create;

public class EnterpriseCreateCommand : IEnterpriseCreateCommand
{
    private readonly AtratoContext _context;
    private readonly IEnterpriseAuditCreateCommand _auditCreateCommand;

    public EnterpriseCreateCommand(AtratoContext context, IEnterpriseAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<EnterpriseQueryData> Execute(EnterpriseCreateRequest request, Guid userId)
    {
        Enterprise doc = new()
        {
            CityId = request.CityId,
            Email = request.Email,
            Identification = request.Identification,
            Name = request.Name,
            Picture = request.Picture,
            ShiftEnd = request.ShiftEnd,
            ShiftStart = request.ShiftStart,
            State = request.State,
            TimeZoneId = request.TimeZoneId,
            Phone = request.Phone,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();
        
        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Create, userId));

        return new EnterpriseQueryData()
        {
            Id = doc.Id,
            Email = doc.Email,
            Identification = doc.Identification,
            Name = doc.Name,
            Picture = doc.Picture,
            ShiftEnd = doc.ShiftEnd,
            ShiftStart = doc.ShiftStart,
            State = doc.State,
            TimeZoneId = doc.TimeZoneId,
            Phone = doc.Phone,
            CityId = doc.CityId,
        };
    }
}