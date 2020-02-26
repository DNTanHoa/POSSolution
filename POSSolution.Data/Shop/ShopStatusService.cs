using Microsoft.EntityFrameworkCore;
using POSSolution.Application.Context;
using POSSolution.Application.Models;
using POSSolution.Data.Shop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSolution.Data.Shop
{
    public class ShopStatusService : IShopStatusService
    {
        private readonly POSContext _context;

        public ShopStatusService(POSContext context)
        {
            _context = context;
        }

        public async Task<int> AddShopStatus(AddShopStatusRequest request)
        {
            var shopStatus = new ShopStatus
            {
                statusName = request.statusName,
                createUser = "admin", //TODO: Get UserName Login
                createDate = DateTime.Now,
                updateDate = DateTime.Now,
            };
            _context.ShopStatuses.Add(shopStatus);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteShopStatus(Guid statusId)
        {
            var existShopStatus = _context.ShopStatuses.FirstOrDefault(item => item.statusId.Equals(statusId));
            _context.ShopStatuses.Remove(existShopStatus);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ShopStatus>> GetAll()
        {
            return await _context.ShopStatuses.ToListAsync();
        }

        public async Task<int> UpdateShopStatus(Guid statusId, UpdateShopStatusRequest request)
        {
            var existShopStatus = _context.ShopStatuses.FirstOrDefault(item => item.statusId.Equals(statusId));
            if(existShopStatus != null)
            {
                existShopStatus.statusName = request.statusName;
                existShopStatus.updateDate = DateTime.Now;
                existShopStatus.createUser = "admin"; //TODO: Get UserName Login
            }
            return await _context.SaveChangesAsync();
        }
    }
}
