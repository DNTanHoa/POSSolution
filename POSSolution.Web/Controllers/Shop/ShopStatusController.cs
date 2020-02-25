using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using POSSolution.Application.Context;
using POSSolution.Data.Shop;
using POSSolution.Web.Models.Shop;

namespace POSSolution.Web.Controllers.Shop
{
    public class ShopStatusController : Controller
    {
        public POSSolution.Web.ServiceLocator.ServiceLocator serviceLocator;
        private readonly POSContext _context;
        private readonly IWebHostEnvironment _env;

        public ShopStatusController(POSContext context, IWebHostEnvironment environment)
        {
            serviceLocator = new ServiceLocator.ServiceLocator(context);
            this._context = context;
            this._env = environment;
        }

        public IActionResult Index()
        {
            var shopStatusService = serviceLocator.GetService<IShopStatusService>();
            var model = new ShopStatusListViewModel();
            if(shopStatusService != null)
            {
                model.ShopStatuses = shopStatusService.GetAll().Result;
            }
            return View("Views/Shop/ShopStatusListView.cshtml", model);
        }
    }
}