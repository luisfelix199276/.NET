using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Repository.Interface.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; set; }       
        void Commit();
    }
}
