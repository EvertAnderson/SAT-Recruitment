using Sat.Recruitment.BL.Rules.IRule;
using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace Sat.Recruitment.BL.Rules
{
    public class ValidateUser
    {
        public User obj { get; set; }
        public List<string> errorMessages { get; set; }

        public ValidateUser(string name, string email, string address, string phone, string userType, string money)
        {
            obj = new User
            {
                Name = name,
                Email = email,
                Address = address,
                Phone = phone,
                UserType = userType,
                Money = decimal.Parse(money)
            };

            ValidateErrors(obj);
            obj = obj.UserType != null ? ValidateGift(obj) : obj;
            obj.Email = obj.Email != null ? NormalizeEmail(obj.Email) : obj.Email;
        }
        private User ValidateGift(User obj)
        {
            Decimal percentage = 0;

            if (obj.UserType == "Normal")
            {
                if(obj.Money > 100)
                {
                    percentage = Convert.ToDecimal(0.12);
                } else if(obj.Money > 10)
                {
                    percentage = Convert.ToDecimal(0.8);
                }
            } else if (obj.UserType == "SuperUser")
            {
                if (obj.Money > 100)
                {
                    percentage = Convert.ToDecimal(0.20);
                }
            } else if (obj.UserType == "Premium")
            {
                if (obj.Money > 100)
                {
                    percentage = Convert.ToDecimal(2);
                }
            }

            obj.Money += (obj.Money * percentage);

            return obj;
        }

        private string NormalizeEmail(string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

        public User GetUser() => obj;

        public string GetErrors()
        {
            string sErrors = string.Empty;
            foreach (var item in errorMessages)
            {
                sErrors += (item + " ");
            }
            return sErrors.TrimEnd();
        }

        private void ValidateErrors(User obj)
        {
            var rules = new List<IRules>
            {
                new NameRule(obj.Name),
                new EmailRule(obj.Email),
                new AddressRule(obj.Address),
                new PhoneRule(obj.Phone)
            };

            errorMessages = new List<string>();

            rules.ForEach(rule =>
            {
                var error = rule.Validate();
                if (!string.IsNullOrWhiteSpace(error))
                    errorMessages.Add(error);
            });
        }

        public bool isDuplicated(List<User> bdUsers)
        {
            var isDuplicated = false;
            foreach (var item in bdUsers)
            {
                if (item.Email == obj.Email || item.Phone == obj.Phone)
                    isDuplicated = true;
                else if (item.Name == obj.Name && item.Address == obj.Address)
                {
                    isDuplicated = true;
                    throw new Exception("User is duplicated");
                }
            }
            return isDuplicated;
        }
    }
}
