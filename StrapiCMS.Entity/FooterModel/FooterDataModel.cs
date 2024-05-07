using StrapiCMS.Entity.ContactsModel;
using StrapiCMS.Entity.LinksModel;
using StrapiCMS.Entity.LogoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.FooterModel
{
    public class FooterDataModel
    {
        public int id { get; set; }
        public List<LinksDataModel>? socialLinks { get; set; }
        public List<LinksDataModel>? legalLinks { get; set; }
        public List<LinksDataModel>? menuLinks { get; set; }
        public LogoDataModel? footerLogo { get; set; }
        public ContactsDataModel? contacts { get; set; }

    }
}
