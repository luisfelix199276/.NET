using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Store.Core.Repository.Interface.GenericRepository;
using Store.Repository.Context;
using System.Collections.Generic;

namespace Store.Repository.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private SqlServerContext _databaseConfig { get; set; }
        private IConfiguration _configuration { get; set; }

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            _databaseConfig = new SqlServerContext(_configuration);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> all = null;

            using (var db = _databaseConfig.Context)
            {
                all = db.GetAll<TEntity>();
                db.Close();
            }

            return all;
        }

        public virtual TEntity GetById(long id)
        {
            TEntity entity = null;

            using (var db = _databaseConfig.Context)
            {
                entity = db.Get<TEntity>(id);
                db.Close();
            }

            return entity;
        }

        public virtual long Insert(TEntity entity)
        {
            long identity = 0;

            using (var db = _databaseConfig.Context)
            {
                identity = db.Insert(entity);
                db.Close();
            }

            return identity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            using (var db = _databaseConfig.Context)
            {
                db.Update(entity);
                db.Close();
            }

            return entity;
        }

        public virtual bool Delete(TEntity entity)
        {
            bool success = false;

            using (var db = _databaseConfig.Context)
            {
                success = db.Delete(entity);
                db.Close();
            }

            return success;
        }

        public virtual TEntity InsertOrUpdate(TEntity entity, long pk)
        {
            if (pk == 0)
            {
                Insert(entity);
            }
            else
            {
                TEntity entityDatabase = GetById(pk);

                if (entityDatabase != null)
                {
                    Update(entity);
                }
            }

            return entity;
        }
    }
}
