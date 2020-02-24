using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace POSSolution.Web.Controllers.Dashboards
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Dashboards/DashBoardView.cshtml");
        }
    }
}
