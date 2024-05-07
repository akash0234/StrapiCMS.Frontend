using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.Enums
{
    public class StateList
    {
        public static Dictionary<string, string> States = new Dictionary<string, string>
        {
            { "New South Wales", "NSW" },
            { "Victoria", "VIC" },
            { "Queensland", "QLD" },
            { "Tasmania", "TAS" },
            { "South Australia", "SA" },
            { "Western Australia", "WA" },
            { "Northern Territory", "NT" },
            { "Australian Capital Territory", "ACT" }
        };
    }
}
