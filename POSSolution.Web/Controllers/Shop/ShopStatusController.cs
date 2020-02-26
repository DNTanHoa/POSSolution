using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using POSSolution.Application.Context;
using POSSolution.Data.Shop;
using POSSolution.Data.Shop.DataTransferObject;
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
            model.ShopStatuses = shopStatusService?.GetAll().Result;
            return View("Views/Shop/ShopStatusListView.cshtml", model);
        }

        public IActionResult ShowAddNewPage()
        {
            var model = new ShopStatusDetailViewModel();
            return View("Views/Shop/ShopStatusDetailView.cshtml", model);
        }

        public async Task<IActionResult> InsertShopStatus([FromForm]ShopStatusDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var shopStatusService = serviceLocator.GetService<IShopStatusService>();
                var addShopStatusRequest = new AddShopStatusRequest
                {
                    statusName = model.name
                };
                await shopStatusService.AddShopStatus(addShopStatusRequest);
                TempData["message"] = $"Trạng thái {model.name} đã được thêm";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Views/Shop/ShopStatusDetailView.cshtml", model);
            }
        }

        public IActionResult ShowEditPage(Guid statusId)
        {
            var editItem = _context.ShopStatuses.FirstOrDefault(model => model.statusId.Equals(statusId));
            var model = new ShopStatusDetailViewModel
            {
                name = editItem.statusName,
                statusId = statusId
            };
            return View("Views/Shop/ShopStatusEditView.cshtml", model);
        }

        public async Task<IActionResult> UpdateShopStatus(Guid statusId, [FromForm]ShopStatusDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var shopStatusService = serviceLocator.GetService<IShopStatusService>();
                var updateShopStatusRequest = new UpdateShopStatusRequest
                {
                    statusName = model.name
                };
                await shopStatusService.UpdateShopStatus(statusId, updateShopStatusRequest);
                TempData["message"] = $"Trạng thái {model.name} đã được cập nhật";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Views/Shop/ShopStatusEditView.cshtml", model);
            }
        }

        public async Task<IActionResult> DeleteShopStatus(Guid statusId)
        {
            var shopStatusService = serviceLocator.GetService<IShopStatusService>();
            await shopStatusService.DeleteShopStatus(statusId);
            TempData["message"] = "Xóa Bỏ Trạng Thái Thành Công";
            return RedirectToAction("Index");
        }
    }
}