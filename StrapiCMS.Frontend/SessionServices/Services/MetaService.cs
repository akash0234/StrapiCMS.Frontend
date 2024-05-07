using StrapiCMS.Entity.PageModel;
using StrapiCMS.Frontend.SessionServices.Repositories;

namespace StrapiCMS.Frontend.SessionServices.Services
{
    // MetaService.cs
    public class MetaService : IMetaService
    {
        private SeoModel _meta;

       

        public SeoModel Meta
        {
            get => _meta;
            set
            {
                _meta = value;
                OnMetaChanged();
            }
        }

        public event EventHandler MetaChanged;

        public async Task SetMetaAsync(SeoModel meta)
        {
            Meta = meta;
        }

        protected virtual void OnMetaChanged()
        {
            MetaChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}
