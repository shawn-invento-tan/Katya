using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KatyaLoyalty.Payloads.CustomerWeb.Auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "email_required")]
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginRequest(HttpRequest request)
        {

        }
    }
}
