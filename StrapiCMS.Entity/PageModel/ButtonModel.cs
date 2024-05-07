using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.PageModel
{
    public class ButtonModel
    {
        public int id { get; set; }
        public string url { get; set; }
        public bool newTab { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }
}
