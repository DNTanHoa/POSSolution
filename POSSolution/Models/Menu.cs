using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Models
{
    public class Menu
    {
        public int menuId { get; set; }

        public string code { get; set; }

        public string note { get; set; }

        public ICollection<MenuItem> items { get; set; }

        public string createUser { get; set; }

        public DateTime? createDate { get; set; }

        public DateTime? updateDate { get; set; }
    }
}
