using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Models
{
    public class Shop
    {
        public Guid shopId { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string image { get; set; }

        public string note { get; set; }

        public ICollection<Region> regions { get; set; }

        public string status { get; set; }

        public string createUser { get; set; }

        public DateTime? createDate { get; set; }

        public DateTime? updateDate { get; set; }
    }
}
