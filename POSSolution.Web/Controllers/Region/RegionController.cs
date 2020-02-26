using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSSolution.Application.Context;
using POSSolution.Data.Region;
using POSSolution.Web.Models.Region;

namespace POSSolution.Web.Controllers.Region
{
    public class RegionController : Controller
    {
        public POSSolution.Web.ServiceLocator.ServiceLocator serviceLocator;
        private readonly POSContext _context;

        public RegionController(POSContext context)
        {
            _context = context;
            serviceLocator = new ServiceLocator.ServiceLocator(context);
        }

        public IActionResult Index()
        {
            var model = new RegionListViewModel();
            var adminRegionService = serviceLocator.GetService<IAdminRegionService>();
            model.regions = adminRegionService.GetAll().Result;
            return View("Views/Region/RegionListView.cshtml", model);
        }
    }
}