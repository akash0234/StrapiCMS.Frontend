using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.PageModel
{
    public class ContentSectionModel : ContentSectionBaseModel
    {
    }
    public class ContentSectionBaseModel
    {
        public ContentSectionBaseModel() { }
        public int id { get; set; }
        public string __component { get; set; }
    }

    public class SectionHero : ContentSectionBaseModel
    {
        public string title { get; set; }
        public string description { get; set; }

        public ImageDataModel? picture { get; set; }

        public List<ButtonModel> buttons { get; set; }


    }
    public class SectionFeatures : ContentSectionBaseModel
    {
        public string heading { get; set; }
        public string description { get; set; }
        public string sectionClass { get; set; }
        public bool? isSlider { get; set; }


        public List<FeatureDataModel> feature { get; set; }


    }

  
}
