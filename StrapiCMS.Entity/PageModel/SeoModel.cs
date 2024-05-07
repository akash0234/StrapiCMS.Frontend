using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.PageModel
{
    public class SeoModel
    {
        public int id { get; set; }
        public string? metaTitle { get; set; }
        public string? metaDescription { get; set; }
        public string? keywords { get; set; }
        public ImageDataModel? shareImage { get; set; }
    }
}
