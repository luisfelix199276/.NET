using Store.API.Model.Request.Post;
using Store.API.Model.Response.Get;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Application.Interface
{
    public interface ICustomerApp
    {
        Task<List<GetCustomerResponseModelView>> Get();
        Task<long> Insert(PostCustomerRequestViewModel customerRequest);
    }
}
