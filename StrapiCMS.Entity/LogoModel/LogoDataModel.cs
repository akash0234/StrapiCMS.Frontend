using StrapiCMS.Entity.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.LogoModel
{
    public class LogoDataModel
    {
        public int id { get; set; }
        public string logoText { get; set; }
        public ImageDataModel logoImg { get; set; }

    }
}
