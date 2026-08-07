using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Guide;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.GuideQueryObject;

public class GuideQueryObject : IGuideQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Guide> _query;

    public GuideQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Guide.AsQueryable();
    }

    public IGuideQueryObject Clear()
    {
        _query = _context.Guide.AsQueryable();
        return this;
    }

    public IGuideQueryObject ForId(Guid id)
    {
        _query = from g in _query
            where g.Id == id
            select g;

        return this;
    }

    public IGuideQueryObject ForState(bool state)
    {
        _query = from g in _query
            where g.State == state
            select g;

        return this;
    }

    public IGuideQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from g in _query
            where g.EnterpriseId == enterpriseId
            select g;

        return this;
    }

    public IGuideQueryObject ForFile(Guid fileId)
    {
        _query = from g in _query
            where g.FileId == fileId
            select g;

        return this;
    }

    public async Task<List<GuideQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from g in _query.AsNoTracking()
            join f in _context.FileDb on g.FileId equals f.Id
            join e in _context.Enterprise on g.EnterpriseId equals e.Id
            select new GuideQueryData
            {
                Id = g.Id,
                Title = g.Title,
                Body = g.Body,
                FileId = g.FileId,
                File = f.Name,
                EnterpriseId = g.EnterpriseId,
                Enterprise = e.Name,
                Date = g.Date,
                State = g.State
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<GuideQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from g in _query.AsNoTracking()
            join f in _context.FileDb on g.FileId equals f.Id
            join e in _context.Enterprise on g.EnterpriseId equals e.Id
            select new GuideQueryData
            {
                Id = g.Id,
                Title = g.Title,
                Body = g.Body,
                FileId = g.FileId,
                File = f.Name,
                EnterpriseId = g.EnterpriseId,
                Enterprise = e.Name,
                Date = g.Date,
                State = g.State
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
