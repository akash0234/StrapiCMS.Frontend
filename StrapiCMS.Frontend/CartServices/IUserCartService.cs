using StrapiCMS.Entity.CartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Frontend.CartServices
{
    public interface IUserCartService
    {
        event Action<CartDataModel> OnCartValueChanged;
        Task<bool> AddToCartAsync(string userId, int productId, int productQty);
        Task<bool> UpdateToCartAsync(string userId, int productId, int productQty);
        Task<bool> RemoveFromCartAsync(string userId, int productId);   
        Task<bool> UpdateTempUserIdCartAsync(string userId);   
        // Other interface methods...
        Task<CartDataModel?> GetCartAsync(string userId);
        Task<string> CreateTempUser();
        Task<string> GetUserID();
    }
}
