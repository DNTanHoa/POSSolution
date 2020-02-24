using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using POSSolution.Application.Context;
using POSSolution.Application.Models;
using POSSolution.Data.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSSolution.Web.Models.Shop
{
    public class ShopDetailViewModel
    {

        public ShopDetailViewModel()
        {
            statusList = new List<SelectListItem>();
        }

        [Required]
        public string name { get; set; }

        [Required]
        public string address { get; set; }

        public IFormFile imageFile { get; set; }

        public string image { get; set; }

        public IEnumerable<SelectListItem> statusList { get; set; }

        public string note { get; set; }

        public string status { get; set; }
        
    }
}
