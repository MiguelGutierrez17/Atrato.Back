using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.News;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.NewsQueryObject;

public class NewsQueryObject : INewsQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<News> _query;

    public NewsQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.News.AsQueryable();
    }

    public INewsQueryObject Clear()
    {
        _query = _context.News.AsQueryable();
        return this;
    }

    public INewsQueryObject ForId(Guid id)
    {
        _query = from n in _query
            where n.Id == id
            select n;

        return this;
    }

    public INewsQueryObject ForState(bool state)
    {
        _query = from n in _query
            where n.State == state
            select n;

        return this;
    }

    public INewsQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from n in _query
            where n.EnterpriseId == enterpriseId
            select n;

        return this;
    }

    public INewsQueryObject ForFile(Guid fileId)
    {
        _query = from n in _query
            where n.FileId == fileId
            select n;

        return this;
    }

    public async Task<List<NewsQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from n in _query.AsNoTracking()
            join e in _context.Enterprise on n.EnterpriseId equals e.Id
            join f in _context.FileDb on n.FileId equals (Guid?)f.Id into files
            from f in files.DefaultIfEmpty()
            select new NewsQueryData
            {
                Id = n.Id,
                Title = n.Title,
                Body = n.Body,
                FileId = n.FileId,
                File = f != null ? f.Name : null,
                State = n.State,
                StartDate = n.StartDate,
                EndDate = n.EndDate,
                EnterpriseId = n.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<NewsQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from n in _query.AsNoTracking()
            join e in _context.Enterprise on n.EnterpriseId equals e.Id
            join f in _context.FileDb on n.FileId equals (Guid?)f.Id into files
            from f in files.DefaultIfEmpty()
            select new NewsQueryData
            {
                Id = n.Id,
                Title = n.Title,
                Body = n.Body,
                FileId = n.FileId,
                File = f != null ? f.Name : null,
                State = n.State,
                StartDate = n.StartDate,
                EndDate = n.EndDate,
                EnterpriseId = n.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}