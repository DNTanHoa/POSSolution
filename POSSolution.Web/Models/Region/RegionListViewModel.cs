using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSSolution.Web.Models.Region
{
    public class RegionListViewModel
    {
        public RegionListViewModel()
        {
            regions = new List<Application.Models.Region>();
        }

        public List<Application.Models.Region> regions { get; set; }
    }
}
