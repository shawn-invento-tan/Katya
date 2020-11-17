using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Payloads.CustomerWeb.Auth
{
    public class LoginResponse : AjaxResponse
    {
        public LoginResponse() : base() { }
        public LoginResponse(Exception ex) : base(ex) { }
    }
}
