using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("sys_user_nhan_hang")]
    public class sys_user_nhan_hang_db
    {
        public string id { get; set; }
        public long? id_tinh { get; set; }
        public long? id_quan { get; set; }
        public string dia_chi_cu_the { get; set; }
        public string id_user { get; set; }
        public string full_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
