using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Payloads.CustomerWeb.Auth
{
    public class RegistrationResponse : AjaxResponse
    {
        public RegistrationResponse() : base() { }
        public RegistrationResponse(Exception ex) : base(ex) { }
    }
}
