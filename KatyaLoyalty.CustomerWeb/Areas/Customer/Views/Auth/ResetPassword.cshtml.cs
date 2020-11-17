using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KatyaLoyalty.CustomerWeb.Areas.Customer.Views.Auth
{
    public class ResetPasswordModel
    {
        public string Identifier { get; set; }
        public string Token { get; set; }
        
        public ResetPasswordModel(string identifier, string token)
        {
            Identifier = identifier;
            Token = token;
        }
    }
}
