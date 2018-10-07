using AutoMapper;
using Store.Core.Entity.Entities;
using Store.Core.Entity.Model;
using Store.Core.Repository.Interface.UoW;
using Store.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CustomerService(IMapper mapper,
            IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;            
        }

        public async Task<long> Insert(Customers customer)
        {
            customer.GuidCustomer = Guid.NewGuid();
            customer.CreationDate = DateTime.UtcNow;
            customer.Active = true;
            return await _uow.CustomerRepository.Insert(customer);
        }

        public Task<IEnumerable<Customers>> Get() {
            return _uow.CustomerRepository.GetAll();
        }       
    }
}
