using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Models
{
    public class ShopStatus
    {
        public Guid statusId { get; set; }

        public string statusName { get; set; }

        public string createUser { get; set; }

        public DateTime? createDate { get; set; }

        public DateTime? updateDate { get; set; }
    }
}
