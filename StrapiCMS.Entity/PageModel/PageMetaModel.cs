using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.PageModel
{
    
    
    public class PageMetaModel
    {
        public Pagination pagination { get; set; } =  new Pagination();
    }
    


    public class Pagination
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }
       

    }
    public class MetaModel
    {
        public MetaPagination pagination { get; set; } = new MetaPagination();
    }

    public class MetaPagination
    {
        public int total { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
    }
}
