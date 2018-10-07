using Dapper.Contrib.Extensions;
using Store.Core.Repository.Interface.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.GenericRepository
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, new()
    {
        private readonly IDbTransaction _transaction;
        private IDbConnection _connection => _transaction.Connection;

        public RepositoryAsync(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> all = null;

            all = await _connection.GetAllAsync<TEntity>(_transaction);

            return all;
        }

        public async virtual Task<TEntity> GetById(long id)
        {
            TEntity entity = null;

            entity = await _connection.GetAsync<TEntity>(id, _transaction);

            return entity;
        }

        public async virtual Task<long> Insert(TEntity entity)
        {
            long identity = 0;

            identity = await _connection.InsertAsync(entity, _transaction);

            return identity;
        }

        public async virtual Task<IEnumerable<long>> InsertMany(IEnumerable<TEntity> entities)
        {
            IList<long> identities = new List<long>();

            foreach (var entity in entities)
            {
                long identity = 0;
                identity = await _connection.InsertAsync(entity, _transaction);

                identities.Add(identity);
            }

            return identities;
        }

        public async virtual Task<TEntity> Update(TEntity entity)
        {
            await _connection.UpdateAsync(entity, _transaction);

            return entity;
        }

        public async virtual Task<bool> Delete(TEntity entity)
        {
            bool success = false;

            success = await _connection.DeleteAsync(entity, _transaction);

            return success;
        }

        public async virtual Task<TEntity> InsertOrUpdate(TEntity entity, long pk)
        {
            if (pk == 0)
            {
                await Insert(entity);
            }
            else
            {
                TEntity entityDatabase = await GetById(pk);

                if (entityDatabase != null)
                {
                    await Update(entity);
                }
            }

            return entity;
        }
    }
}
