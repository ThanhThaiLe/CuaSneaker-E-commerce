using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("sys_group_user")]
    public class sys_group_user_db
    {
        public string id { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
        public int? type_user { get; set; }
    }
}
