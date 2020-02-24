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
                status = request.status
            };
            _context.Shops.Add(shop);
            return await _context.SaveChangesAsync();
        }

        public Task<int> DeleteShop(Guid shopId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<POSSolution.Application.Models.Shop>> GetAll()
        {
            return await _context.Shops.ToListAsync();
        }

        public Task<int> UpdateShop(Guid shopId, UpdateShopRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
