using StrapiCMS.Entity.FooterModel;
using StrapiCMS.Entity.NavbarModel;
using StrapiCMS.Entity.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.GlobalModel
{
    public class GlobalDataModel
    {
        public GenericDataModel<GLobalBaseModel> data { get; set; } = new GenericDataModel<GLobalBaseModel>();
    }
    public class GLobalBaseModel
    {
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string locale { get; set; }

        public SeoModel metadata { get; set; }
        public ImageDataModel favicon { get; set; }
        public NavbarDataModel navbar { get; set; }
        public FooterDataModel footer { get; set; }

    }

}
