using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.Repository.Interface.GenericRepository
{
    public interface IRepositoryAsync<TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetById(long id);
        Task<IEnumerable<TEntity>> GetAll();        
        Task<long> Insert(TEntity entity);
        Task<IEnumerable<long>> InsertMany(IEnumerable<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<TEntity> InsertOrUpdate(TEntity entity, long pk);
    }
}
