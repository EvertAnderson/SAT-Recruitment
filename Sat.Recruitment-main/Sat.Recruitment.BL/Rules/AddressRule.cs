using Sat.Recruitment.BL.Rules.IRule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.BL.Rules
{
    public class AddressRule : IRules
    {
        public string Address { get; set; }
        public AddressRule(string name)
        {
            Address = name;
        }
        
        public string Validate()
        {
            var errorMessage = string.Empty;

            if (Address == null) errorMessage = "The address is required";

            return errorMessage;
        }
    }
}
