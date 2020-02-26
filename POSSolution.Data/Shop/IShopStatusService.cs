using POSSolution.Application.Models;
using POSSolution.Data.Shop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSSolution.Data.Shop
{
    public interface IShopStatusService
    {
        public Task<int> AddShopStatus(AddShopStatusRequest request);

        public Task<int> UpdateShopStatus(Guid statusId, UpdateShopStatusRequest request);
        
        public Task<int> DeleteShopStatus(Guid statusId);

        public Task<List<ShopStatus>> GetAll();
    }
}
