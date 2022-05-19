using Sat.Recruitment.BL.Rules.IRule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.BL.Rules
{
    public class NameRule : IRules
    {
        public string Name { get; set; }
        public NameRule(string name)
        {
            Name = name;
        }
        
        public string Validate()
        {
            var errorMessage = string.Empty;

            if (Name == null) errorMessage = "The name is required";

            return errorMessage;
        }
    }
}
