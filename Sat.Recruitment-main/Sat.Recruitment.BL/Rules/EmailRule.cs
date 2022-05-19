using Sat.Recruitment.BL.Rules.IRule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.BL.Rules
{
    public class EmailRule : IRules
    {
        public string Email { get; set; }
        public EmailRule(string email)
        {
            Email = email;
        }
        
        public string Validate()
        {
            var errorMessage = string.Empty;

            if (Email == null) errorMessage = "The email is required";

            return errorMessage;
        }
    }
}
