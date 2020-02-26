using POSSolution.Data.Region.DataTranfersObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSSolution.Data.Region
{
    public interface IAdminRegionService
    {
        public Task<List<POSSolution.Application.Models.Region>> GetAll();

        public Task<int> AddRegion(AddRegionRequest request);

        public Task<int> UpdateRegion(int regionId,UpdateRegionRequest request);

        public Task<int> DeleteRegion(int regionId);
    }
}
