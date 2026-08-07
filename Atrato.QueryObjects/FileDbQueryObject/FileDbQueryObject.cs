using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.FileDb;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.FileDbQueryObject;

public class FileDbQueryObject : IFileDbQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<FileDb> _query;

    public FileDbQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.FileDb.AsQueryable();
    }

    public IFileDbQueryObject Clear()
    {
        _query = _context.FileDb.AsQueryable();
        return this;
    }

    public IFileDbQueryObject ForId(Guid id)
    {
        _query = from f in _query
            where f.Id == id
            select f;

        return this;
    }

    public IFileDbQueryObject ForIds(List<Guid> ids)
    {
        _query = from f in _query
            where ids.Contains(f.Id)
            select f;

        return this;
    }

    public IFileDbQueryObject ForState(bool state)
    {
        _query = from f in _query
            where f.State == state
            select f;

        return this;
    }

    public IFileDbQueryObject ForUser(Guid userId)
    {
        _query = from f in _query
            where f.UserId == userId
            select f;

        return this;
    }

    public async Task<List<FileDbQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from f in _query.AsNoTracking()
            join u in _context.User on f.UserId equals u.Id
            select new FileDbQueryData
            {
                Id = f.Id,
                Name = f.Name,
                Extension = f.Extension,
                DateUpload = f.DateUpload,
                TypeFile = f.TypeFile,
                StorageId = f.StorageId,
                UserId = f.UserId,
                User = u.Name + " " + u.LastName,
                State = f.State
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<FileDbQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from f in _query.AsNoTracking()
            join u in _context.User on f.UserId equals u.Id
            select new FileDbQueryData
            {
                Id = f.Id,
                Name = f.Name,
                Extension = f.Extension,
                DateUpload = f.DateUpload,
                TypeFile = f.TypeFile,
                StorageId = f.StorageId,
                UserId = f.UserId,
                User = u.Name + " " + u.LastName,
                State = f.State
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
