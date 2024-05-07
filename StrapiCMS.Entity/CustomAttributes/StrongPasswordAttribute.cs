using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.CustomAttributes
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = value as string;
            

            List<string> errorMessages = new List<string>();
            if(!string.IsNullOrEmpty(password))
            {
                if (password.Length < 8)
                {
                    errorMessages.Add("Password must be at least 8 characters long.");
                }

                if (!password.Any(char.IsUpper))
                {
                    errorMessages.Add("Password must contain at least one capital letter.");
                }

                if (!password.Any(char.IsLower))
                {
                    errorMessages.Add("Password must contain at least one small letter.");
                }

                if (!password.Any(char.IsDigit))
                {
                    errorMessages.Add("Password must contain at least one number.");
                }

                if (!Regex.IsMatch(password, @"[!@#$%^&*()_+}{:;'?/>,.<]\w"))
                {
                    errorMessages.Add("Password must contain at least one special character.");
                }

                if (errorMessages.Any())
                {
                    return new ValidationResult(string.Join(" ", errorMessages));
                }
            }
            

            return ValidationResult.Success;
        }
    }
}
