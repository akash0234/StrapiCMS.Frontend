using StrapiCMS.Entity.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.PageModel
{
    public class ImageDataModel
    {
        public GenericDataModel<ImageBaseModel> data { get; set; }
        
    }
    public class ImageListDataModel
    {
        public List<GenericDataModel<ImageBaseModel>> data { get; set; } = new List<GenericDataModel<ImageBaseModel>>();
      
    }
    public class ImageBaseModel
    {
        public string name { get; set; }
        public string alternativeText { get; set; }
        public string caption { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public double size { get; set; }
        public string url { get; set; }
        public string previewUrl { get; set; }
        public string provider { get; set; }
        public string provider_metadata { get; set; }
        public Formats? formats { get; set; }   
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class Formats
    {
        public ImageBaseModel? thumbnail { get; set; }
    }
}
