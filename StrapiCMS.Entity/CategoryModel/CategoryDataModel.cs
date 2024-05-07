using StrapiCMS.Entity.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.CategoryModel
{
    public class CategoryDataModel
    {
        public GenericDataModel<CategoryData> data { get; set; }
    }

    public class CategoryData
    {
        public string title { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
    }

    
}
