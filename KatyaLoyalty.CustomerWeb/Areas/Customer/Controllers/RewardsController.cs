using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KatyaLoyalty.CustomerWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class RewardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("~/customer/rewards/info/{rewardId}")]
        public IActionResult Info(int rewardId)
        {
            return View();
        }
    }
}
