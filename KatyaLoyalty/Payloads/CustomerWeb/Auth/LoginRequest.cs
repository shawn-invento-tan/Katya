using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace KatyaLoyalty.Payloads.CustomerWeb.Auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "email_required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "password_required")]
        public string Password { get; set; }
        
        public LoginRequest(HttpRequest request)
        {
            Email = request.Form["email"];
            Password = request.Form["password"];
        }

        public LoginResponse Validate()
        {
            LoginResponse response = new LoginResponse();
            ValidationContext validationContext = new ValidationContext(this);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, validationContext, validationResults, true);
            response.Errors = validationResults.Select(x => x.ErrorMessage).ToList();
            return response;
        }
    }
}
