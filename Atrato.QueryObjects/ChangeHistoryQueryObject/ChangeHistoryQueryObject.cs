using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.ChangeHistory;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.ChangeHistoryQueryObject;

public class ChangeHistoryQueryObject : IChangeHistoryQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<ChangeHistory> _query;

    public ChangeHistoryQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.ChangeHistory.AsQueryable();
    }

    public IChangeHistoryQueryObject Clear()
    {
        _query = _context.ChangeHistory.AsQueryable();
        return this;
    }

    public IChangeHistoryQueryObject ForId(Guid id)
    {
        _query = from ch in _query
            where ch.Id == id
            select ch;

        return this;
    }

    public IChangeHistoryQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from ch in _query
            where ch.EnterpriseId == enterpriseId
            select ch;

        return this;
    }

    public IChangeHistoryQueryObject ForEntityType(Guid entityTypeId)
    {
        _query = from ch in _query
            where ch.EntityTypeId == entityTypeId
            select ch;

        return this;
    }

    public IChangeHistoryQueryObject ForUserAction(Guid userActionId)
    {
        _query = from ch in _query
            where ch.UserActionId == userActionId
            select ch;

        return this;
    }

    public IChangeHistoryQueryObject ForActionUser(Guid actionUser)
    {
        _query = from ch in _query
            where ch.ActionUser == actionUser
            select ch;

        return this;
    }

    public IChangeHistoryQueryObject ForItem(Guid itemId)
    {
        _query = from ch in _query
            where ch.ItemId == itemId
            select ch;

        return this;
    }

    public async Task<List<ChangeHistoryQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from ch in _query.AsNoTracking()
            join et in _context.EntityType on ch.EntityTypeId equals et.Id
            join ua in _context.UserAction on ch.UserActionId equals ua.Id
            join u in _context.User on ch.ActionUser equals u.Id
            join e in _context.Enterprise on ch.EnterpriseId equals e.Id
            select new ChangeHistoryQueryData
            {
                Id = ch.Id,
                EntityTypeId = ch.EntityTypeId,
                EntityType = et.Name,
                ItemId = ch.ItemId,
                UserActionId = ch.UserActionId,
                UserAction = ua.Name,
                ValueName = ch.ValueName,
                PreviousValue = ch.PreviousValue,
                NewValue = ch.NewValue,
                ActionUser = ch.ActionUser,
                ActionUserLabel = u.Name + " " + u.LastName,
                ActionDate = ch.ActionDate,
                EnterpriseId = ch.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<ChangeHistoryQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from ch in _query.AsNoTracking()
            join et in _context.EntityType on ch.EntityTypeId equals et.Id
            join ua in _context.UserAction on ch.UserActionId equals ua.Id
            join u in _context.User on ch.ActionUser equals u.Id
            join e in _context.Enterprise on ch.EnterpriseId equals e.Id
            select new ChangeHistoryQueryData
            {
                Id = ch.Id,
                EntityTypeId = ch.EntityTypeId,
                EntityType = et.Name,
                ItemId = ch.ItemId,
                UserActionId = ch.UserActionId,
                UserAction = ua.Name,
                ValueName = ch.ValueName,
                PreviousValue = ch.PreviousValue,
                NewValue = ch.NewValue,
                ActionUser = ch.ActionUser,
                ActionUserLabel = u.Name + " " + u.LastName,
                ActionDate = ch.ActionDate,
                EnterpriseId = ch.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
