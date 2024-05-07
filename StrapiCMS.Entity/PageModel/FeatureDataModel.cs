using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.PageModel
{
    public class FeatureDataModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool? showLink { get; set; }
        public bool? newTab { get; set; }
        public string url { get; set; }
        public string text { get; set; }
        public ImageDataModel media { get; set; }
    }
}
