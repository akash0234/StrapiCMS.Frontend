using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using StrapiCMS.ApiClient.Repositories;
using StrapiCMS.Entity.CartModel;
using StrapiCMS.Entity.Enums;
using StrapiCMS.Entity.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Frontend.CartServices
{
    public class UserCartService : IUserCartService
    {
        private readonly ProtectedLocalStorage _protectedLocalStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;


        public UserCartService(ProtectedLocalStorage protectedLocalStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _protectedLocalStorage = protectedLocalStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public event Action<CartDataModel> OnCartValueChanged;

        public async Task<bool> AddToCartAsync(string userId, int productId, int productQty)
        {
            try
            {
                var cartDataModel = new CartDataModel();

                // Get existing cart data
                var existingCart = await GetCartAsync(userId);

                // If cart already exists, merge the new data with existing cart
                if (existingCart != null)
                {
                    var product = existingCart.ProductList.FirstOrDefault(x => x.ProductId == productId);

                    if (product != null)
                    {
                        product.ProductQty += productQty;
                    }
                    else
                    {
                        existingCart.ProductList.Add(new ProductQtyDataModel() { ProductId = productId, ProductQty = productQty });
                    }
                    cartDataModel = existingCart;


                }
                else
                {
                    cartDataModel.UserId = userId;
                    cartDataModel.ProductList.Add(new ProductQtyDataModel() { ProductId = productId, ProductQty = productQty });
                }

                // Save updated cart data
                await _protectedLocalStorage.SetAsync(LocalStorageKeys.UserCart.ToString() + "__" + cartDataModel.UserId, cartDataModel);
                await Task.Run(async () =>
                {
                    await Task.Yield();
                    OnCartValueChanged?.Invoke(cartDataModel); // Notify subscribers about the cart value change

                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateToCartAsync(string userId, int productId, int productQty)
        {
            try
            {
                var cartDataModel = new CartDataModel();

                // Get existing cart data
                var existingCart = await GetCartAsync(userId);

                // If cart already exists, merge the new data with existing cart
                if (existingCart != null)
                {
                    var product = existingCart.ProductList.FirstOrDefault(x => x.ProductId == productId);

                    if (product != null)
                    {
                        product.ProductQty = productQty;
                    }
                    else
                    {
                        existingCart.ProductList.Add(new ProductQtyDataModel() { ProductId = productId, ProductQty = productQty });
                    }
                    cartDataModel = existingCart;


                }
                else
                {
                    return false;
                }

                // Save updated cart data
                await _protectedLocalStorage.SetAsync(LocalStorageKeys.UserCart.ToString() + "__" + cartDataModel.UserId, cartDataModel);
                await Task.Run(async () =>
                {
                    await Task.Yield();
                    OnCartValueChanged?.Invoke(cartDataModel); // Notify subscribers about the cart value change

                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateTempUserIdCartAsync(string userId)
        {
            try
            {

                // Get existing cart data
                var existingCart = await GetCartAsync(LocalStorageKeys.TempUserID.ToString());
                existingCart.UserId = userId;
                // If cart already exists, merge the new data with existing cart
                if (existingCart != null)
                {


                    // Save updated cart data
                    await _protectedLocalStorage.SetAsync(LocalStorageKeys.UserCart.ToString() + "__" + userId, existingCart);
                    
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> RemoveFromCartAsync(string userId, int productId)
        {
            try
            {
                // Get existing cart data
                var existingCart = await GetCartAsync(userId);

                // If cart exists and contains the product, remove it
                if (existingCart != null)
                {
                    existingCart.ProductList.RemoveAll(p => p.ProductId == productId);

                    // Save updated cart data
                    await _protectedLocalStorage.SetAsync(LocalStorageKeys.UserCart.ToString() + "__" + userId, existingCart);

                    OnCartValueChanged?.Invoke(existingCart); // Notify subscribers about the cart value change
                    return true;
                }

                return false; // Cart does not exist or product not found in the cart
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Method to retrieve the current cart data
        public async Task<CartDataModel?> GetCartAsync(string userId)
        {
            var result = await _protectedLocalStorage.GetAsync<CartDataModel>(LocalStorageKeys.UserCart.ToString() + "__" + userId);
            var cartValue = result.Success ? result.Value : null;

            return cartValue;

        }
        public async Task<string> CreateTempUser()
        {
            var userId = Guid.NewGuid().ToString();
            await _protectedLocalStorage.SetAsync(LocalStorageKeys.TempUserID.ToString(), userId);
            return userId;
        }

        public async Task<string> GetUserID()
        {
            string UserID = string.Empty;
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;

            if (user.Identity?.IsAuthenticated ?? false)
            {
                UserID = user.Identity?.Name;
            }
            else
            {

                // Handle unauthenticated user scenario
                var hasTempUser = await _protectedLocalStorage.GetAsync<string>(LocalStorageKeys.TempUserID.ToString());
                if (hasTempUser.Success)
                {
                    UserID = hasTempUser.Value;
                }
            }
            return UserID;
        }

    }

}
