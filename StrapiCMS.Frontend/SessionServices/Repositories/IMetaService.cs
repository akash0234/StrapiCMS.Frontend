using StrapiCMS.Entity.PageModel;

namespace StrapiCMS.Frontend.SessionServices.Repositories
{
    public interface IMetaService
    {
        SeoModel Meta { get; set; }
        event EventHandler MetaChanged;

        Task SetMetaAsync(SeoModel meta);
    }
}
