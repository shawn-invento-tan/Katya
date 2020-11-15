using Katya.Security;
using KatyaLoyalty.Db.MsSql;
using KatyaLoyalty.Payloads.CustomerWeb.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatyaLoyalty.Services.CustomerWeb
{
    public class AuthService
    {
        public RegistrationResponse RegisterCustomer(RegistrationRequest registrationRequest)
        {
            RegistrationResponse registrationResponse = registrationRequest.Validate();
            if (registrationResponse.Success == true)
            {
                try
                {
                    KatyaLoyaltyMsSqlContext context = new KatyaLoyaltyMsSqlContext();
                    Authenticator.EncryptWithPbkdf2(registrationRequest.Password, out string passwordSalt, out string passwordHash);
                    if (context.Customers.Any(x => x.Email.ToLower() == registrationRequest.Email.ToLower()))
                    {
                        registrationResponse.Errors.Add("email_exists");
                        registrationResponse.Success = false;
                        return registrationResponse;
                    }
                    else if (context.Customers.Any(x=>x.PhoneCountryCode == registrationRequest.PhoneCountryCode && x.PhoneNumber == registrationRequest.PhoneNumber))
                    {
                        registrationResponse.Errors.Add("phone_number_exists");
                        registrationResponse.Success = false;
                        return registrationResponse;
                    }
                    Customer customer = new Customer()
                    {
                        Email = registrationRequest.Email,
                        PhoneCountryCode = registrationRequest.PhoneCountryCode,
                        PhoneNumber = registrationRequest.PhoneNumber,
                        CreatedDate = DateTime.Now,
                        PasswordSalt = passwordSalt,
                        PasswordHash = passwordHash
                    };
                    context.Customers.Add(customer);
                    context.SaveChanges();

                    CustomerProfile customerProfile = new CustomerProfile()
                    {
                        CustomerId = customer.Id,
                        FirstName = registrationRequest.FirstName
                    };
                    context.CustomerProfiles.Add(customerProfile);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    registrationResponse = new RegistrationResponse(ex);
                }
            }
            return registrationResponse;
        }

        public LoginResponse AuthenticateCustomer(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            return loginResponse;
        }
    }
}
