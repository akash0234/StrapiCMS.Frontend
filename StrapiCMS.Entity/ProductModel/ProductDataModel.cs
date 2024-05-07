using StrapiCMS.Entity.CategoryModel;
using StrapiCMS.Entity.PageModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StrapiCMS.Entity.ProductModel
{

    public class ProductDataModel
    {
        public GenericDataModel<Product> data { get; set; } = new GenericDataModel<Product>();

    }
    public class ProductListDataModel
    {
        public List<GenericDataModel<Product>> data { get; set; } = new List<GenericDataModel<Product>>();
        public MetaModel meta { get; set; } = new MetaModel();
    }

    public class Product
    {

    
        public string title { get; set; }
    
        public string modelName { get; set; }

      
        public double price { get; set; } // Assuming price can have decimals, using double. Consider decimal for financial calculations.
        
        public string desc { get; set; }
      
        public int qtyPerPack { get; set; }
        public ImageListDataModel img { get; set; }
        public CategoryDataModel category { get; set; }
    }

    

    

    

}
