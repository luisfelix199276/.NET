using Store.Core.Entity.Entities;
using Store.Core.Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.Service.Interface
{
    public interface ICustomerService
    {
        Task<long> Insert(Customers customer);
        Task<IEnumerable<Customers>> Get();
    }
}
