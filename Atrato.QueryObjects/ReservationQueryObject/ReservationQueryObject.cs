using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Reservation;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.ReservationQueryObject;

public class ReservationQueryObject : IReservationQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Reservation> _query;

    public ReservationQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Reservation.AsQueryable();
    }

    public IReservationQueryObject Clear()
    {
        _query = _context.Reservation.AsQueryable();
        return this;
    }

    public IReservationQueryObject ForId(Guid id)
    {
        _query = from r in _query
            where r.Id == id
            select r;

        return this;
    }

    public IReservationQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from r in _query
            join ws in _context.WorkStation on r.WorkStationId equals ws.Id
            join wp in _context.Workplace on ws.WorkplaceId equals wp.Id
            where wp.EnterpriseId == enterpriseId
            select r;

        return this;
    }

    public IReservationQueryObject ForWorkplace(Guid workplaceId)
    {
        _query = from r in _query
            join ws in _context.WorkStation on r.WorkStationId equals ws.Id
            where ws.WorkplaceId == workplaceId
            select r;

        return this;
    }

    public IReservationQueryObject ForWorkStation(Guid workStationId)
    {
        _query = from r in _query
            where r.WorkStationId == workStationId
            select r;

        return this;
    }

    public IReservationQueryObject ForUser(Guid userId)
    {
        _query = from r in _query
            where r.UserId == userId
            select r;

        return this;
    }

    public IReservationQueryObject ForReservationState(Guid reservationStateId)
    {
        _query = from r in _query
            where r.ReservationStateId == reservationStateId
            select r;

        return this;
    }

    public IReservationQueryObject ForReservationType(Guid reservationTypeId)
    {
        _query = from r in _query
            where r.ReservationTypeId == reservationTypeId
            select r;

        return this;
    }

    public IReservationQueryObject ForStartDateGreaterThan(DateTime startDate)
    {
        _query = from r in _query
            where r.StartDate > startDate
            select r;

        return this;
    }

    public IReservationQueryObject ForStartDateLessThan(DateTime startDate)
    {
        _query = from r in _query
            where r.StartDate < startDate
            select r;

        return this;
    }

    public IReservationQueryObject ForEndDateGreaterThan(DateTime endDate)
    {
        _query = from r in _query
            where r.EndDate > endDate
            select r;

        return this;
    }

    public IReservationQueryObject ForEndDateLessThan(DateTime endDate)
    {
        _query = from r in _query
            where r.EndDate < endDate
            select r;

        return this;
    }

    public async Task<List<ReservationQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from r in _query.AsNoTracking()
            join rs in _context.ReservationState on r.ReservationStateId equals rs.Id
            join rt in _context.ReservationType on r.ReservationTypeId equals rt.Id
            join ws in _context.WorkStation on r.WorkStationId equals ws.Id
            join u in _context.User on r.UserId equals u.Id
            select new ReservationQueryData
            {
                Id = r.Id,
                ReservationStateId = r.ReservationStateId,
                ReservationState = rs.Name,
                ReservationTypeId = r.ReservationTypeId,
                ReservationType = rt.Name,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                WorkStationId = r.WorkStationId,
                WorkStation = ws.Name,
                CancelByExpireTime = r.CancelByExpireTime,
                UserId = r.UserId,
                User = u.Name + " " + u.LastName,
                CheckInDate = r.CheckInDate,
                CheckOutDate = r.CheckOutDate,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt,
                IdempotencyId = r.IdempotencyId
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<ReservationQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from r in _query.AsNoTracking()
            join rs in _context.ReservationState on r.ReservationStateId equals rs.Id
            join rt in _context.ReservationType on r.ReservationTypeId equals rt.Id
            join ws in _context.WorkStation on r.WorkStationId equals ws.Id
            join u in _context.User on r.UserId equals u.Id
            select new ReservationQueryData
            {
                Id = r.Id,
                ReservationStateId = r.ReservationStateId,
                ReservationState = rs.Name,
                ReservationTypeId = r.ReservationTypeId,
                ReservationType = rt.Name,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                WorkStationId = r.WorkStationId,
                WorkStation = ws.Name,
                CancelByExpireTime = r.CancelByExpireTime,
                UserId = r.UserId,
                User = u.Name + " " + u.LastName,
                CheckInDate = r.CheckInDate,
                CheckOutDate = r.CheckOutDate,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt,
                IdempotencyId = r.IdempotencyId
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
