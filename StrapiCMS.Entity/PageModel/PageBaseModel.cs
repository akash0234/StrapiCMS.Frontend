using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StrapiCMS.Entity.PageModel
{
    public class PageBaseModel
    {
        public List<GenericDataModel<PageModel>> data { get; set; }
        public PageMetaModel meta { get; set; }
    }
    
    public class PageModel
    {
        public string shortName { get; set; }
        public string slug { get; set; }
        public string heading { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
        public string locale { get; set; }

        public List<object> contentSections { get; set; }
        public SeoModel seo { get; set; }
    }

}
