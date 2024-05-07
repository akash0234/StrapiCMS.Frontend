using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.AuthResponseModel.AuthResponseModel
{
    public class AuthResponseModel
    {
        public string jwt { get; set; }
        public StrapiUser user { get; set; }
    }
    public class StrapiUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string provider { get; set; }
        public bool confirmed { get; set; }
        public bool blocked { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

}
