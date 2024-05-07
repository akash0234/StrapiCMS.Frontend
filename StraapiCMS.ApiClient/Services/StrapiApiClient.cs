using Microsoft.Extensions.Configuration;
using StrapiCMS.ApiClient.Repositories;
using StrapiSharp.Requests;
using StrapiSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrapiSharp.Enums;
using System.Text.Json;
using StrapiCMS.Entity.ResponseModel;
using System.Text.Json.Serialization;
using StrapiCMS.Entity.PageModel;
using StrapiCMS.Entity.Enums;
using StrapiCMS.Common.Helper;
using StrapiCMS.Entity.GlobalModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using StrapiCMS.Entity.Dto;
using StrapiSharp.Requests.Convenience;
using StrapiCMS.Entity.AuthResponseModel.AuthResponseModel;
using System.Collections;
using StrapiSharp.Models;
using StrapiCMS.Entity.ResponseModel.UpdateUserResponseModel;

namespace StrapiCMS.ApiClient.Services
{
    public class StrapiApiClient : IStrapiApiClient
    {

        private readonly Strapi _strapi;

        private readonly string AuthToken;

        private readonly IConfiguration _configuration;

        public string ErrorMsg { get; set; }

        public StrapiApiClient(Strapi strapi, IConfiguration configuration)
        {
            _strapi = strapi;
            _configuration = configuration;
            AuthToken = _configuration["Strapi:APIToken"];
        }

        public async Task<T> GetCollectionsType<T>(string collectionName,  int start, int limit) where T : new()
        {
            try
            {
               

                var request = new QueryRequest(collectionName);
                //request.Populate();

                request.PopulateAll();
                
                request.StartingAt(start);
                request.LimitTo(limit);

                request.Sort("createdAt", SortDirection.Descending);

               
                var result1 = await _strapi.ExecuteAsync(request, AuthToken);

                var products =  JsonSerializer.Deserialize<T>(result1);

                // Assuming you will populate the result list with the response data
                // result.AddRange(result1.Items); // Adjust this based on the actual response structure

                return products;
            }
            catch (StrapiRequestException ex)
            {
                var error = JsonSerializer.Deserialize<Entity.ResponseModel.Response>(ex.Response)!.Error;
                throw new Exception(error.Message);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<T> GetCollectionsType<T>(string collectionName, int collectionId) where T : new()
        {
            try
            {


                var request = new QueryRequest(collectionName);
                //request.Populate();

                request.PopulateAll();

                request.Filter(FilterType.EqualTo, "id", collectionId.ToString());
                request.Sort("createdAt", SortDirection.Descending);


                var result1 = await _strapi.ExecuteAsync(request, AuthToken);

                var collection = JsonSerializer.Deserialize<T>(result1);

                // Assuming you will populate the result list with the response data
                // result.AddRange(result1.Items); // Adjust this based on the actual response structure

                return collection;
            }
            catch (StrapiRequestException ex)
            {
                var error = JsonSerializer.Deserialize<Entity.ResponseModel.Response>(ex.Response)!.Error;
                throw new Exception(error.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        //public async Task<T> GetCollectionsTypeByCustomParam<T>(string collectionName,string filterKey, string searchValue) where T : new()
        //{
        //    try
        //    {


        //        var request = new QueryRequest(collectionName);
        //        //request.Populate();

        //        request.PopulateAll();

        //        request.Filter(FilterType.EqualTo, filterKey, searchValue.ToString());
        //        //request.Sort("createdAt", SortDirection.Descending);


        //        var result1 = await _strapi.ExecuteAsync(request, AuthToken);

        //        var collection = JsonSerializer.Deserialize<T>(result1);

        //        // Assuming you will populate the result list with the response data
        //        // result.AddRange(result1.Items); // Adjust this based on the actual response structure

        //        return collection;
        //    }
        //    catch (StrapiRequestException ex)
        //    {
        //        var error = JsonSerializer.Deserialize<Entity.ResponseModel.Response>(ex.Response)!.Error;
        //        throw new Exception(error.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}
        public async Task<PageBaseModel> GetPageBySlug(string url)
        {
            var request = new QueryRequest("pages");
            request.Filters.Add(new StrapiSharp.Models.RequestFilter()
            {
                Field = "slug",
                Value = url,

            });

            var result1 = await _strapi.ExecuteAsync(request, AuthToken);
            var pageModel = JsonSerializer.Deserialize<PageBaseModel>(result1);

            return pageModel;
        }


        public async Task<GlobalDataModel> GetGlobalDetails()
        {
            try
            {
                var request = new QueryRequest("global");
                var fieldsToPopulate = new List<PopulateFields>
                {
                    PopulateFields.MetadataShareImage,
                    PopulateFields.Favicon,
                    PopulateFields.NotificationBannerLink,
                    PopulateFields.NavbarLinks,
                    PopulateFields.NavbarLogoImg,
                    PopulateFields.FooterLogoImg,
                    PopulateFields.FooterMenuLinks,
                    PopulateFields.FooterLegalLinks,
                    PopulateFields.FooterSocialLinks,
                    PopulateFields.FooterContacts,



                    // Add other fields as needed
                };

                foreach (var item in fieldsToPopulate)
                {
                    request.Populate(PopulateFieldExtensions.GetStringValue(item));

                }

                var result1 = await _strapi.ExecuteAsync(request, AuthToken);
                var globalModel = JsonSerializer.Deserialize<GlobalDataModel>(result1);

                return globalModel;
            }
            
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public async Task<AuthResponseModel> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
               

                var request = new RegisterRequest(registerDto.username, registerDto.email, registerDto.password);


                var response = await _strapi.ExecuteAsync(request);

                var token = JsonSerializer.Deserialize<AuthResponseModel>(response);
                await UpdateUserDetails(registerDto, token.user.id);
                return token;
            }
            catch (StrapiRequestException ex)
            {

                var error = JsonSerializer.Deserialize<Entity.ResponseModel.Response>(ex.Response)!.Error;

                ErrorMsg = error.Message;

                return null;
            }
            

        }
        private async Task UpdateUserDetails(RegisterDto registerDto, int userid)
        {
            try
            {
                var request = new CustomRequest(RequestMethod.Put, "users", $"/{userid}");
                request.SetBody(JsonSerializer.Serialize(new { firstName = registerDto.firstName, lastName = registerDto.lastName, postalCode = registerDto.postalCode, country = registerDto.country,state = registerDto.state }));

                var response = await _strapi.ExecuteAsync(request, AuthToken);

                var updateUserModel = JsonSerializer.Deserialize<UpdateUserResponseModel>(response);

            }
            catch (StrapiRequestException ex)
            {

                var error = JsonSerializer.Deserialize<Entity.ResponseModel.Response>(ex.Response)!.Error;

                throw new Exception(error.Message);
            }
        }
        public async Task<AuthResponseModel> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var request = new LoginRequest(loginDto.email, loginDto.password);


                var response = await _strapi.ExecuteAsync(request);

                var token = JsonSerializer.Deserialize<AuthResponseModel>(response);

                return token;
            }
            catch (StrapiRequestException ex)
            {

                var error = JsonSerializer.Deserialize<Entity.ResponseModel.Response>(ex.Response)!.Error;

                throw new Exception(error.Message);
            }


        }


    }
}
