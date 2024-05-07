using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.Constans
{
    public class PasswordValidationConstants
    {
        public const string MinLengthErrorMessage = "Password must be at least 8 characters long.";
        public const string CapitalLetterErrorMessage = "Password must contain at least one capital letter.";
        public const string SmallLetterErrorMessage = "Password must contain at least one small letter.";
        public const string NumberErrorMessage = "Password must contain at least one number.";
        public const string SpecialCharacterErrorMessage = "Password must contain at least one special character.";
        public const string RequiredErrorMessage = "Password is required.";
    }
}
