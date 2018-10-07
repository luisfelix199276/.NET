using Dapper;
using Store.Core.Entity.Entities;
using Store.Core.Repository.Interface;
using Store.Repository.GenericRepository;
using System.Data;
using System.Threading.Tasks;

namespace Store.Repository.Repository
{
    public class CustomerRepository : RepositoryAsync<Customers>, ICustomerRepository
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection => _transaction.Connection;

        public CustomerRepository(IDbTransaction transaction)
            : base(transaction)
        {
            _transaction = transaction;
        }

        public async Task<bool> IsThereCpf(string cpf)
        {
            int numberCustomers;

            string sql = $"SELECT count(Id) FROM [Customers] WHERE CPF = @CPF )";

            numberCustomers = await _connection.QueryFirstAsync<int>(sql, new { CPF = cpf }, _transaction);

            return numberCustomers == 0;
        }
    }
}
