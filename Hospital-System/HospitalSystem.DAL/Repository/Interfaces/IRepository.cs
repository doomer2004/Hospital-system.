namespace HospitalSystem.DAL.Repository.Interfaces;

public interface IRepository<TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity>
{
    IQueryable<TEntity> FromSQLInterapted(FormattableString sql);
    
    bool Insert(TEntity? entity, bool saveChanges = true);
    Task<bool> InsertAsync(TEntity? entity, bool saveChanges = true);
    
    bool InsertRange(IEnumerable<TEntity> entities, bool saveChanges = true);
    Task<bool> InsertRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
    
    bool Update(TEntity? entity, bool saveChanges = true);
    Task<bool> UpdateAsync(TEntity? entity, bool saveChanges = true);
    
    bool UpdateRange(IEnumerable<TEntity> entities, bool saveChanges = true);
    Task<bool> UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
    
    bool Delete(TEntity? entity, bool saveChanges = true);
    Task<bool> DeleteAsync(TEntity? entity, bool saveChanges = true);
    
    bool DeleteRange(IEnumerable<TEntity> entities, bool saveChanges = true);
    Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
}