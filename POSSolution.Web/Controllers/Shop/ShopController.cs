using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POSSolution.Application.Context;
using POSSolution.Application.Models;
using POSSolution.Data.Shop;
using POSSolution.Data.Shop.DataTransferObject;
using POSSolution.Web.Helpers;
using POSSolution.Web.Models.Shop;
using POSSolution.Web.ServiceLocator;

namespace POSSolution.Web.Controllers.Shop
{
    public class ShopController : Controller
    {
        public POSSolution.Web.ServiceLocator.ServiceLocator serviceLocator;
        private readonly POSContext _context;
        private readonly IWebHostEnvironment _env;

        public ShopController(POSContext context, IWebHostEnvironment environment)
        {
            serviceLocator = new ServiceLocator.ServiceLocator(context);
            _context = context;
            _env = environment;
        }

        public async Task<ActionResult> Index()
        {
            var adminShopService = serviceLocator.GetService<IAdminShopService>();
            var model = new ShopListViewModel();
            model.shops = await adminShopService.GetAll();
            return View("Views/Shop/ShopListView.cshtml",model);
        }

        public IActionResult ShowAddNewPage()
        {
            var model = new ShopDetailViewModel();
            model.statusList = GetShopStatus();
            return View("Views/Shop/ShopDetailView.cshtml",model);
        }

        [HttpPost("[action]")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> InsertShop(ShopDetailViewModel model)
        {
            if(ModelState.IsValid)
            {
                var request = new AddShopRequest
                {
                    name = model.name,
                    address = model.address,
                    note = model.note,
                    status = model.status,
                    image = model.image
                };
                var adminShopService = serviceLocator.GetService<IAdminShopService>();
                await adminShopService.AddShop(request);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Nội Dung Nhập Không Phù Hợp");
                return View("Views/Shop/ShopDetailView.cshtml", model);
            }
        }

        [HttpPost("[action]")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ImageUpload([FromForm]IFormFile file,[FromForm]ShopDetailViewModel model)
        {
            if(file != null && file.Length > 0)
            {
                var imagePath = await ImageUploadHelper.ImageUpload(file, _env);
                ViewData["FileLocation"] = imagePath;
                model.image = imagePath;
            }
            model.statusList = GetShopStatus();
            
            return View("Views/Shop/ShopDetailView.cshtml", model);
        }

        #region support function
        public List<SelectListItem> GetShopStatus()
        {
            var shopStatusService = serviceLocator.GetService<IShopStatusService>();
            List<ShopStatus> statuses = shopStatusService.GetAll().Result;
            List<SelectListItem> selecItems = new List<SelectListItem>();
            foreach (var status in statuses)
            {
                selecItems.Add(new SelectListItem(status.statusName, status.statusName));
            }
            return selecItems;
        }
        #endregion
    }
}