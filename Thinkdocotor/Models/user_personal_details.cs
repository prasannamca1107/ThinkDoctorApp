using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinkdocotor.Models.TableClass
{
    public class user_personal_details
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string img_name { get; set; }
        public string img_path { get; set; }
        public string title { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public DateTime? dob { get; set; }
        public string lang { get; set; }
        public string tel1 { get; set; }
        public string tel2 { get; set; }
        public string tel3 { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string NHSno { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city_town { get; set; }
        public string county_state { get; set; }
        public int CountryCodes_id { get; set; }
        public string postcode { get; set; }
        public int? created_by { get; set; }
        public int? modified_by { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? modified_date { get; set; }
    }
}
