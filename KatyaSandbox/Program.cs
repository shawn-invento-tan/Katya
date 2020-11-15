using KatyaLoyalty.Db.MsSql;
using KatyaLoyalty.Payloads.CustomerWeb.Auth;
using KatyaLoyalty.Services.CustomerWeb;
using Newtonsoft.Json;
using System;

namespace KatyaSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthService authService = new AuthService();
            DateTime now = DateTime.Now;
            string fullName = $"Customer {now.Ticks}";
            string email = $"{now.Ticks}";

            RegistrationRequest registrationRequest = new RegistrationRequest()
            {
                FirstName = fullName,
                Email = email,
                PhoneCode = "60",
                PhoneNumber = "123a",
                Password = "test123"
            };

            authService.RegisterCustomer(registrationRequest);
        }
    }
}
