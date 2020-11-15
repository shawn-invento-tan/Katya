using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KatyaLoyalty.Payloads.CustomerWeb.Auth;
using KatyaLoyalty.Services.CustomerWeb;
using Microsoft.AspNetCore.Mvc;

namespace KatyaLoyalty.CustomerWeb.Areas.Customer.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RecoverPassword()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ajax(string action)
        {
            AuthService authService = new AuthService();
            switch(action)
            {
                case "login":
                    RegistrationRequest registrationRequest = new RegistrationRequest(Request);
                    return Json(authService.RegisterCustomer(registrationRequest));
                default:
                    break;
            }
            return Json(null);
        }
    }
}
