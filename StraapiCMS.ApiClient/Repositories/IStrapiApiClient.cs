
using StrapiCMS.Entity.Dto;
using StrapiCMS.Entity.GlobalModel;
using StrapiCMS.Entity.PageModel;
using StrapiCMS.Entity.AuthResponseModel.AuthResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.ApiClient.Repositories
{
    public interface IStrapiApiClient
    {
        public string ErrorMsg { get; set; }
        Task<T> GetCollectionsType<T>(string collectionName, int start, int limit) where T : new();
        Task<T> GetCollectionsType<T>(string collectionName,int collectionId) where T : new();
        //Task<T> GetCollectionsTypeByCustomParam<T>(string collectionName, string filterKey, string searchValue) where T : new();
        Task<PageBaseModel> GetPageBySlug(string url);
        Task<GlobalDataModel> GetGlobalDetails();
        Task<AuthResponseModel> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseModel> LoginAsync(LoginDto loginDto);
    }
}
