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

        [HttpPost]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            if(file != null && file.Length > 0)
            {
                var imagePath = @"\Upload\Images\";
                var uploadPath = _env.WebRootPath + imagePath;
                
                if(!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);
                
                var uniqFileName = Guid.NewGuid().ToString();
                var fileName = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + fileName;
                imagePath = imagePath + @"\";
                var filePath = @".." + Path.Combine(imagePath, fileName);

                using(var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                ViewData["FileLocation"] = filePath;
            }
            
            return View("Views/Shop/ShopDetailView.cshtml");
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