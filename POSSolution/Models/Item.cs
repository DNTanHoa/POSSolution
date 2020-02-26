using System;
using System.Collections;
using System.Collections.Generic;

namespace POSSolution.Application.Models
{
    public class Item
    {
        public int itemId { get; set; }

        public string itemName { get; set; }

        public string itemCode { get; set; }

        public string itemImage { get; set; }

        public decimal? itemPrice { get; set; }

        public ICollection<MenuItem> menus { get; set; } 

        public string createUser { get; set; }

        public DateTime? createDate { get; set; }

        public DateTime? updateDate { get; set; }
    }
}