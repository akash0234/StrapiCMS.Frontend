using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.ContactsModel
{
    
    public class ContactsDataModel
    {
        public int id { get; set; }
        public string location { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
