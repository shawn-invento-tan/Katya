using System;
using System.Collections.Generic;

namespace KatyaLoyalty.Payloads.CustomerWeb
{
    public class AjaxResponse
    {
        public bool Success
        {
            get
            {
                return Errors.Count == 0;
            }
        }
        public List<string> Errors { get; set; }
        public List<string> Exceptions { get; set; }

        public AjaxResponse()
        {
            Errors = new List<string>();
            Exceptions = new List<string>();
        }

        public AjaxResponse(Exception ex)
        {
            Errors = new List<string>() { "unhandled_exception" };
            Exceptions = new List<string>() { ex.Message };
        }
    }
}
