using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Katya.Extensions
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Validates that a string is a valid mobile phone number and returns the country code and national number parts. Validationis done with libphonenumber
        /// </summary>
        /// <param name="rawPhoneNumber"></param>
        /// <param name="countryCode"></param>
        /// <param name="nationalNumber"></param>
        /// <returns></returns>
        public static bool IsValidMobileNumber(this string rawPhoneNumber, out string countryCode, out string nationalNumber)
        {
            try
            {
                PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber phoneNumber = phoneNumberUtil.Parse(rawPhoneNumber, null);
                bool isPossibleNumber = phoneNumberUtil.IsPossibleNumber(phoneNumber);
                bool isPossibleNumberForType = phoneNumberUtil.IsPossibleNumberForType(phoneNumber, PhoneNumberType.MOBILE);
                countryCode = phoneNumber.CountryCode.ToString();
                nationalNumber = phoneNumber.NationalNumber.ToString();
                return isPossibleNumber && isPossibleNumberForType;
            }
            catch
            {
                countryCode = null;
                nationalNumber = null;
                return false;
            }
        }
    }
}
