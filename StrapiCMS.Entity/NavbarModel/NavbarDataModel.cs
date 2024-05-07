using StrapiCMS.Entity.LinksModel;
using StrapiCMS.Entity.LogoModel;
using StrapiCMS.Entity.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.NavbarModel
{
    public class NavbarDataModel
    {
        public int id { get; set; }
        public string logoText { get; set; }
        public LogoDataModel navbarLogo { get; set; }
        public List<LinksDataModel> links { get; set; }
    }
}
