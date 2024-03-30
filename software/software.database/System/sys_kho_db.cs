using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("sys_kho")]
    public class sys_kho_db : IBaseCommon
    {
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
