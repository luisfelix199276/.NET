using Store.Core.Entity.Entities;
using Store.Core.Repository.Interface.GenericRepository;
using System.Threading.Tasks;

namespace Store.Core.Repository.Interface
{
    public interface ICustomerRepository : IRepositoryAsync<Customers>
    {
        Task<bool> IsThereCpf(string cpf);
    }
}
