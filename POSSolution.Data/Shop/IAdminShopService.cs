using POSSolution.Data.Shop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSSolution.Data.Shop
{
    public interface IAdminShopService
    {
        public Task<int> AddShop(AddShopRequest request);
        
        public Task<int> UpdateShop(Guid shopId,UpdateShopRequest request);
        
        public Task<int> DeleteShop(Guid shopId);
        
        public Task<List<POSSolution.Application.Models.Shop>> GetAll();

        public Task<int> AddRegionToShop(AddRegionToShopRequest request);
    }
}
