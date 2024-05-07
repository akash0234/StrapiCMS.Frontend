using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.CartModel
{
    public class CartDataModel
    {
        public string UserId { get; set; }

        public List<ProductQtyDataModel> ProductList { get; set; } = new List<ProductQtyDataModel>();
    }
    public class ProductQtyDataModel
    {
        public int ProductId { get; set;}
        public int ProductQty { get; set;}
    }
}
