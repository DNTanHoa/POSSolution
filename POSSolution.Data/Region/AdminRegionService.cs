using Microsoft.EntityFrameworkCore;
using POSSolution.Application.Context;
using POSSolution.Data.Region.DataTranfersObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSSolution.Data.Region
{
    public class AdminRegionService : IAdminRegionService
    {
        private readonly POSContext _context;

        public AdminRegionService(POSContext context)
        {
            _context = context;
        }

        public async Task<int> AddRegion(AddRegionRequest request)
        {
            var region = new POSSolution.Application.Models.Region
            {
                name = request.name,
                code = request.code,
                shop = request.shop,
                createUser = "Admin", //TODO: Get UserName Login
                createDate = DateTime.Now,
                updateDate = DateTime.Now
            };
            _context.Regions.Add(region);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteRegion(int regionId)
        {
            var existRegion = await _context.Regions.FirstOrDefaultAsync(region => region.regionId.Equals(regionId));
            if(existRegion != null)
            {
                _context.Regions.Remove(existRegion);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Application.Models.Region>> GetAll()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<int> UpdateRegion(int regionId, UpdateRegionRequest request)
        {
            var existRegion = await _context.Regions.FirstOrDefaultAsync(region => region.regionId.Equals(regionId));
            if (existRegion != null)
            {
                existRegion.name = request.name;
                existRegion.code = request.code;
                existRegion.shop = request.shop;
            }
            return await _context.SaveChangesAsync();
        }
    }
}
