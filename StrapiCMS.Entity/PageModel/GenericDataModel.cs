using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.PageModel
{
    public class GenericDataModel<T> where T : class
    {
        public int id { get; set; }
        public T attributes { get; set; }   
    }
}
