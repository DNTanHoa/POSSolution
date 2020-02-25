using Microsoft.EntityFrameworkCore;
using POSSolution.Application.Context;
using POSSolution.Data.Shop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSSolution.Data.Shop
{
    public class AdminShopService : IAdminShopService
    {

        private readonly POSContext _context;

        public AdminShopService(POSContext context)
        {
            _context = context;
        }

        public Task<int> AddRegionToShop(AddRegionToShopRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddShop(AddShopRequest request)
        {
            var shop = new POSSolution.Application.Models.Shop()
            {
                name = request.name,
                address = request.address,
                image = request.image,
                note = request.note,
                status = request.status,
                createUser = "admin", //TODO: Get UserName Login
                createDate = DateTime.Now,
                updateDate = DateTime.Now
            };
            _context.Shops.Add(shop);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteShop(Guid shopId)
        {
            var existShop = await _context.Shops.FirstOrDefaultAsync(shop => shop.shopId == shopId);
            if(existShop != null)
            {
                _context.Shops.Remove(existShop);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<POSSolution.Application.Models.Shop>> GetAll()
        {
            return await _context.Shops.ToListAsync();
        }

        public async Task<int> UpdateShop(Guid shopId, UpdateShopRequest request)
        {
            var existShop = await _context.Shops.FirstOrDefaultAsync(shop => shop.shopId == shopId);
            if( existShop != null)
            {
                existShop.name = request.name;
                existShop.address = request.address;
                existShop.note = request.note;
                existShop.status = request.status;
                existShop.image = request.image;
                existShop.createUser = "admin"; //TODO: Get UserName Login
                existShop.createDate = DateTime.Now;
            }
            return await _context.SaveChangesAsync();
        }
    }
}
