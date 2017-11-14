using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinkdocotor.Models.TableClass
{
    public class master_countrycodes
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryCodeLong { get; set; }
        public string MapReference { get; set; }
        public bool? Active { get; set; }
    }

    public class CountryCodeslist
    {
        public List<master_countrycodes> countryCodesList { get; set; }
    }
}
