using StrapiCMS.Entity.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.Dto
{
    public class RegisterDto
    {

        public string username
        {
            get
            {
                return email;
            }
            set
            {
               
            }
        }
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]

        public string confirmPassword { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "state is Required")]
        public string state { get; set; }
        [Required(ErrorMessage = "country is Required")]
        public string country { get; set; } = "Australia";

        [Required(ErrorMessage = "postalCode is Required")]
        public int? postalCode { get; set; }

    }
}
