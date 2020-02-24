using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Data.Shop.DataTransferObject
{
    public class UpdateShopRequest
    {
        public string name { get; set; }

        public string address { get; set; }

        public string image { get; set; }

        public string note { get; set; }

        public string status { get; set; }
    }
}
