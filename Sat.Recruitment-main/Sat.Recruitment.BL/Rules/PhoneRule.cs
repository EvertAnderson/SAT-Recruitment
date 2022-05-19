using Sat.Recruitment.BL.Rules.IRule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.BL.Rules
{
    public class PhoneRule : IRules
    {
        public string Phone { get; set; }
        public PhoneRule(string name)
        {
            Phone = name;
        }
        
        public string Validate()
        {
            var errorMessage = string.Empty;

            if (Phone == null) errorMessage = "The phone is required";

            return errorMessage;
        }
    }
}
