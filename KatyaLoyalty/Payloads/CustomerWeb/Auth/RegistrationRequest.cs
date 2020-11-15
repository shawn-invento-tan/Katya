using Katya.Extensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public string PhoneCountryCode { get; set; }

        [Required(ErrorMessage = "phone_number_required")]
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
            PhoneCountryCode = request.Form["phoneCountryCode"];
            PhoneNumber = request.Form["phoneNumber"];
            Password = request.Form["password"];
        }
        
        public RegistrationResponse Validate()
        {
            RegistrationResponse response = new RegistrationResponse();
            ValidationContext validationContext = new ValidationContext(this);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, validationContext, validationResults, true);
            response.Errors = validationResults.Select(x => x.ErrorMessage).ToList();
            string rawPhoneNumber = $"{PhoneCountryCode}{PhoneNumber}";
            
            if (rawPhoneNumber.IsValidMobileNumber(out string phoneCountryCode, out string phoneNumber))
            {
                PhoneCountryCode = phoneCountryCode;
                PhoneNumber = phoneNumber;
            }
            else
            {
                response.Errors.Add("phone_number_invalid");
            }

            if (response.Errors.Count > 0)
            {
                response.Success = false;
            }
            return response;
        }
    }
}
