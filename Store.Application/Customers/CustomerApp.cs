using AutoMapper;
using Store.API.Model.Request.Post;
using Store.API.Model.Response.Get;
using Store.Application.Interface;
using Store.Core.Repository.Interface.UoW;
using Store.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Customers
{
    public class CustomerApp : ICustomerApp
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        private readonly ICustomerService _customerService;
        
        public CustomerApp(ICustomerService customerService,
             IMapper mapper,
             IUnitOfWork uow)
        {
            _customerService = customerService;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<GetCustomerResponseModelView>> Get()
        {
            IEnumerable<Store.Core.Entity.Entities.Customers> listCustomers;            

            using (_uow)
            {
                listCustomers = await _customerService.Get();                
            }

            IEnumerable<GetCustomerResponseModelView> customers = _mapper
                .Map<IEnumerable<GetCustomerResponseModelView>>(listCustomers);
            
            return customers.ToList();
        }

        public async Task<long> Insert(PostCustomerRequestViewModel customerRequest)
        {
            Store.Core.Entity.Entities.Customers customer = _mapper.Map<Store.Core.Entity.Entities.Customers>(customerRequest);
            long result;
            using (_uow)
            {
                result = await _customerService.Insert(customer);
            }

            return result;
        }
    }
}
