using Katya.Security;
using KatyaLoyalty.Db.MsSql;
using KatyaLoyalty.Payloads.CustomerWeb.Auth;
using System;
using System.Collections.Generic;
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
                    Customer customer = new Customer()
                    {
                        Email = registrationRequest.Email,
                        PhoneCode = registrationRequest.PhoneCode,
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
    }
}
