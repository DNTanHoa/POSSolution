using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSSolution.Web.Models.Shop
{
    public class ShopStatusDetailViewModel
    {
        [Required(ErrorMessage = "Nhập Tên Trạng Thái")]
        public string name { get; set; }

        public Guid statusId { get; set; }
    }
}
