using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KatyaLoyalty.CustomerWeb.Areas.Customer.Views.Auth;
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
            RegisterModel registerModel = new RegisterModel();
            return View(registerModel);
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
        public IActionResult Ajax(string authAction)
        {
            AuthService authService = new AuthService();
            authAction = authAction.ToLower().Trim();
            switch(authAction)
            {
                case "login":
                    LoginRequest loginRequest = new LoginRequest(Request);
                    return Json(authService.AuthenticateCustomer(loginRequest));
                case "register":
                    RegistrationRequest registrationRequest = new RegistrationRequest(Request);
                    return Json(authService.RegisterCustomer(registrationRequest));
                default:
                    return Json(null);
            }
        }
    }
}
