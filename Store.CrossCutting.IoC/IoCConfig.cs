using Microsoft.Extensions.DependencyInjection;
using Store.Application.Customers;
using Store.Application.Interface;
using Store.Core.Repository.Interface.GenericRepository;
using Store.Core.Repository.Interface.UoW;
using Store.Core.Service;
using Store.Core.Service.Interface;
using Store.Repository.GenericRepository;
using Store.Repository.Repository;

namespace Store.CrossCutting.IoC
{
    public static class IoCConfig
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            #region [ Application ]

            services.AddTransient(typeof(ICustomerApp), typeof(CustomerApp));
            
            #endregion

            #region [ Services ]

            services.AddTransient(typeof(ICustomerService), typeof(CustomerService));   

            #endregion

            #region [ Model ]

            //services.AddTransient(typeof(WorkerContract), typeof(WorkerContractResponse));
            

            #endregion

            #region [ Repository ]

            services.AddScoped<IUnitOfWork, UnitOfWork>(service => new UnitOfWork(connectionString));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            #endregion

            #region [ Config ]

            //services.AddTransient(typeof(IAuthConfigService), typeof(AuthConfigService));

            #endregion
        }
    }
}
