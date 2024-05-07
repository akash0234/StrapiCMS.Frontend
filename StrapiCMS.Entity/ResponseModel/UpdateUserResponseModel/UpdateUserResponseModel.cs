using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.ResponseModel.UpdateUserResponseModel
{
    

    public class UpdateUserResponseModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string provider { get; set; }
        public bool confirmed { get; set; }
        public bool blocked { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Role role { get; set; }
    }


    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
