using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace KatyaLoyalty.Payloads.CustomerWeb.Auth
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "first_name_required")]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "email_required")]
        [EmailAddress(ErrorMessage = "email_format_invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "phone_code_required")]
        public string PhoneCode { get; set; }

        [Required(ErrorMessage = "phone_number_required")]
        [Phone(ErrorMessage = "phone_number_invalid")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "password_required")]
        public string Password { get; set; }

        public RegistrationRequest() { }
        public RegistrationRequest(HttpRequest request)
        {
            FirstName = request.Form["firstName"];
            MiddleName = request.Form["middleName"];
            LastName = request.Form["lastName"];
            Email = request.Form["email"];
            PhoneCode = request.Form["phoneCode"];
            PhoneNumber = request.Form["phoneNumber"];
            Password = request.Form["password"];
        }
        
        public RegistrationResponse Validate()
        {
            RegistrationResponse response = new RegistrationResponse();
            ValidationContext validationContext = new ValidationContext(this);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, validationContext, validationResults, true);
            if (!isValid)
            {
                response.Success = false;
                response.Errors = validationResults.Select(x => x.ErrorMessage).ToList();
            }
            return response;
        }
    }
}
