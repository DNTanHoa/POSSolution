using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Models
{
    public class MenuItem
    {
        public int menuId { get; set; }

        public int itemId { get; set; }

        public Menu menuNavigation { get; set; }

        public Item itemNavigation { get; set; }
    }
}
