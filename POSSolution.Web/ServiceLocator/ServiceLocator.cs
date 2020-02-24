using POSSolution.Application.Context;
using POSSolution.Data.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSSolution.Web.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Map To Service In Application
        /// </summary>
        public IDictionary<object, object> services;

        public ServiceLocator(POSContext _context)
        {
            services = new Dictionary<object, object>();

            ///Register Service
            services.Add(typeof(IAdminShopService), new AdminShopService(_context));
            services.Add(typeof(IShopStatusService), new ShopStatusService(_context));
        }

        public T GetService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch(KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }
    }
}
