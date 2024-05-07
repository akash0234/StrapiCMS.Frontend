using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.Dto
{
    public class LoginDto
    {

        
        [Required(ErrorMessage ="Email is Required")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }
    }
}
