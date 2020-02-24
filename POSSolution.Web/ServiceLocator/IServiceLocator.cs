using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSSolution.Web.ServiceLocator
{
    public interface IServiceLocator
    {
        public T GetService<T>();
    }
}
