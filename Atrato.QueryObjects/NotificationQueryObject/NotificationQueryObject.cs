using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Notification;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.NotificationQueryObject;

public class NotificationQueryObject : INotificationQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Notification> _query;

    public NotificationQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Notification.AsQueryable();
    }

    public INotificationQueryObject Clear()
    {
        _query = _context.Notification.AsQueryable();
        return this;
    }

    public INotificationQueryObject ForId(Guid id)
    {
        _query = from n in _query
            where n.Id == id
            select n;

        return this;
    }

    public INotificationQueryObject ForState(bool state)
    {
        _query = from n in _query
            where n.State == state
            select n;

        return this;
    }

    public INotificationQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from n in _query
            where n.EnterpriseId == enterpriseId
            select n;

        return this;
    }

    public INotificationQueryObject ForUser(Guid userId)
    {
        _query = from n in _query
            where n.Receipter == userId
            select n;

        return this;
    }

    public INotificationQueryObject ForEntityType(Guid entityTypeId)
    {
        _query = from n in _query
            where n.EntityTypeId == entityTypeId
            select n;

        return this;
    }

    public async Task<List<NotificationQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from n in _query.AsNoTracking()
            join et in _context.EntityType on n.EntityTypeId equals et.Id
            join u in _context.User on n.Receipter equals u.Id
            join e in _context.Enterprise on n.EnterpriseId equals e.Id
            select new NotificationQueryData
            {
                Id = n.Id,
                Date = n.Date,
                EntityTypeId = n.EntityTypeId,
                EntityType = et.Name,
                Receipter = n.Receipter,
                ReceipterLabel = u.Name + " " + u.LastName,
                EmailSender = n.EmailSender,
                EmailReceipter = n.EmailReceipter,
                Description = n.Description,
                isEmail = n.isEmail,
                Read = n.Read,
                State = n.State,
                EnterpriseId = n.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<NotificationQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from n in _query.AsNoTracking()
            join et in _context.EntityType on n.EntityTypeId equals et.Id
            join u in _context.User on n.Receipter equals u.Id
            join e in _context.Enterprise on n.EnterpriseId equals e.Id
            select new NotificationQueryData
            {
                Id = n.Id,
                Date = n.Date,
                EntityTypeId = n.EntityTypeId,
                EntityType = et.Name,
                Receipter = n.Receipter,
                ReceipterLabel = u.Name + " " + u.LastName,
                EmailSender = n.EmailSender,
                EmailReceipter = n.EmailReceipter,
                Description = n.Description,
                isEmail = n.isEmail,
                Read = n.Read,
                State = n.State,
                EnterpriseId = n.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
