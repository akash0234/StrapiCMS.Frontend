using StrapiCMS.Entity.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.Enums
{
    public enum PopulateFields
    {
        [PopulateField("metadata.shareImage")]
        MetadataShareImage,

        [PopulateField("favicon")]
        Favicon,

        [PopulateField("notificationBanner.link")]
        NotificationBannerLink,

        [PopulateField("navbar.links")]
        NavbarLinks,

        [PopulateField("navbar.navbarLogo.logoImg")]
        NavbarLogoImg,

        [PopulateField("footer.footerLogo.logoImg")]
        FooterLogoImg,

        [PopulateField("footer.menuLinks")]
        FooterMenuLinks,

        [PopulateField("footer.legalLinks")]
        FooterLegalLinks,

        [PopulateField("footer.socialLinks")]
        FooterSocialLinks,

        [PopulateField("footer.categories")]
        FooterCategories,
        [PopulateField("footer.contacts")]
        FooterContacts,
    }

}
