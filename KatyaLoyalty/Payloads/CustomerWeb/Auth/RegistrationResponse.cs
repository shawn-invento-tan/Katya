using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Payloads.CustomerWeb.Auth
{
    public class RegistrationResponse : AjaxResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Exceptions { get; set; }

        public RegistrationResponse()
        {
            Success = true;
            Errors = new List<string>();
            Exceptions = new List<string>();
        }

        public RegistrationResponse(Exception ex)
        {
            Success = false;
            Errors = new List<string>() { "unhandled_exception" };
            Exceptions = new List<string>() { ex.Message };
        }
    }
}
