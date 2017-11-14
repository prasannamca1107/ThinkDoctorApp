using System;

namespace Thinkdocotor.Models.TableClass
{
    public class users
    {
        public int id { get; set; }
        public string login_id { get; set; }
        public string password { get; set; }
        public string activation_code { get; set; }
        public bool? email_confirm { get; set; }
        public bool? active { get; set; }
        public bool? registration_complete { get; set; }
        public bool? temp_pass_attempted { get; set; }
        public int? user_type_id { get; set; }
        public int? user_access_type_id { get; set; }
        public DateTime? last_login_time { get; set; }
        public int? created_by { get; set; }
        public int? modified_by { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? modified_date { get; set; }
    }
}