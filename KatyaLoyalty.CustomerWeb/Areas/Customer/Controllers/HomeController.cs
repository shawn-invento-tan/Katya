using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KatyaLoyalty.CustomerWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        [Route("/customer/home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
