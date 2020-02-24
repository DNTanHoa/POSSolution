using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace POSSolution.Web.Controllers.Account
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Account/LoginView.cshtml");
        }
    }
}