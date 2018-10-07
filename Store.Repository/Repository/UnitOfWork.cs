using Store.Core.Repository.Interface;
using Store.Core.Repository.Interface.UoW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Store.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private ICustomerRepository _customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get => _customerRepository ?? (_customerRepository = new CustomerRepository(_transaction));
            set => _customerRepository = value;
        }
       
        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public static IUnitOfWork Create(string connectionString)
        {
            return new UnitOfWork(connectionString);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        private void resetRepositories()
        {
            _customerRepository = null;            
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
