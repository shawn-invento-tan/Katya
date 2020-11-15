using Katya.Extensions;
using KatyaLoyalty.Db.MsSql;
using KatyaLoyalty.Payloads.CustomerWeb.Auth;
using KatyaLoyalty.Services.CustomerWeb;
using Newtonsoft.Json;
using PhoneNumbers;
using System;

namespace KatyaSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber phoneNumber = phoneNumberUtil.Parse("+1-2681234567", null);
            Console.WriteLine(phoneNumber.CountryCode);
            Console.WriteLine(phoneNumberUtil.GetRegionCodeForNumber(phoneNumber));

            foreach(string supportedRegion in phoneNumberUtil.GetSupportedRegions())
            {
                int countryCode = phoneNumberUtil.GetCountryCodeForRegion(supportedRegion);
                
                
                try
                {
                    Locale locale = new Locale("EN", supportedRegion);
                    Console.WriteLine($"{locale.GetDisplayCountry("en")}  {countryCode}");

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
