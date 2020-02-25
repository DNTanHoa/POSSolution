using POSSolution.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSSolution.Web.Models.Shop
{
    public class ShopStatusListViewModel
    {
        public ShopStatusListViewModel()
        {
            ShopStatuses = new List<ShopStatus>();
        }

        public List<ShopStatus> ShopStatuses { get; set; }
    }
}
