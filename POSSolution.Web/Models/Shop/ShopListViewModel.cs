using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSSolution.Web.Models.Shop
{
    public class ShopListViewModel
    {
        public ShopListViewModel()
        {
            this.shops = new List<Application.Models.Shop>();
        }

        public List<POSSolution.Application.Models.Shop> shops { get; set; }
    }
}
