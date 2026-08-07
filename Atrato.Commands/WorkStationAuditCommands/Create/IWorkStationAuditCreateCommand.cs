using Atrato.Entities.DTO.WorkStationAudit;

namespace Atrato.Commands.WorkStationAuditCommands.Create;

public interface IWorkStationAuditCreateCommand
{
    Task Execute(WorkStationAuditCreateRequest request);
}