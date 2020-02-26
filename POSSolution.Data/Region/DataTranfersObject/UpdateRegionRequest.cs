using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Data.Region.DataTranfersObject
{
    public class UpdateRegionRequest
    {
        public string name { get; set; }

        public string code { get; set; }

        public POSSolution.Application.Models.Shop shop { get; set; }
    }
}
