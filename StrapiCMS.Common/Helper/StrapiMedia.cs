using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Common.Helper
{
    public class StrapiMedia
    {
        public static string GetStrapiImage(string url, IConfiguration configuration)
        {
            return configuration["Strapi:ServerURI"].Replace("/api", "") + url;
        }
    }
}
