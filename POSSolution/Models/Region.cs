using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Models
{
    public class Region
    {
        public Guid regionId { get; set; }

        public string name { get; set; }

        public Shop shop { get; set; }
    }
}
