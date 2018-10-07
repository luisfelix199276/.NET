namespace Store.Core.Repository.Interface.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity GetById(long id);        
        long Insert(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);
        TEntity InsertOrUpdate(TEntity entity, long pk);
    }
}
