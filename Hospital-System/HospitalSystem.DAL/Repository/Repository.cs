using System.Collections;
using System.Linq.Expressions;
using HospitalSystem.DAL.Context;
using HospitalSystem.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HospitalSystem.DAL.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _table;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public Type EntityType => ((IQueryable<TEntity>) _table).ElementType;

    public Type ElementType { get; }
    public Expression Expression => ((IQueryable<TEntity>) _table).Expression;

    public IQueryProvider Provider => ((IQueryable<TEntity>) _table).Provider;

    public IEnumerator<TEntity> GetEnumerator()
    {
        return ((IEnumerable<TEntity>)_table).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IQueryable<TEntity> FromSQLInterapted(FormattableString sql)
    {
        return _table.FromSqlInterpolated(sql);
    }

    public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
    {
        return ((IAsyncEnumerable<TEntity>)_table).GetAsyncEnumerator(cancellationToken);
    }

    public bool Insert(TEntity? entity, bool saveChanges = true)
    {
        _table.Add(entity);
        return saveChanges && _context.SaveChanges() > 0;
    }

    public async Task<bool> InsertAsync(TEntity? entity, bool saveChanges = true)
    {
        await _table.AddAsync(entity);
        return saveChanges && (await _context.SaveChangesAsync()) > 0;
    }

    public bool InsertRange(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        _table.AddRange(entities);
        return saveChanges && _context.SaveChanges() > 0;
    }

    public async Task<bool> InsertRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        await _table.AddRangeAsync(entities);
        return saveChanges && (await _context.SaveChangesAsync()) > 0;
    }

    public bool Update(TEntity? entity, bool saveChanges = true)
    {
        _table.Update(entity);
        return saveChanges && _context.SaveChanges() > 0;
    }

    public async Task<bool> UpdateAsync(TEntity? entity, bool saveChanges = true)
    {
        _table.Update(entity);
        return saveChanges && (await _context.SaveChangesAsync()) > 0;
    }

    public bool UpdateRange(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        _table.UpdateRange(entities);
        return saveChanges && _context.SaveChanges() > 0;
    }

    public async Task<bool> UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        _table.UpdateRange(entities);
        return saveChanges && (await _context.SaveChangesAsync()) > 0;
    }

    public bool Delete(TEntity? entity, bool saveChanges = true)
    {
        _table.Remove(entity);
        return saveChanges && _context.SaveChanges() > 0;
    }

    public async Task<bool> DeleteAsync(TEntity? entity, bool saveChanges = true)
    {
        _table.Remove(entity);
        return saveChanges && (await _context.SaveChangesAsync()) > 0;
    }

    public bool DeleteRange(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        _table.RemoveRange(entities);
        return saveChanges && _context.SaveChanges() > 0;
    }

    public async Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        _table.RemoveRange(entities);
        return saveChanges && (await _context.SaveChangesAsync()) > 0;
    }
    }
