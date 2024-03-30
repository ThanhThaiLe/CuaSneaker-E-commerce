using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("sys_banner")]
    public class sys_banner_db : IBaseCommon
    {
        public long id { get; set; }
        public string id_type { get; set; }
        public string image_web { get; set; }
        public string image_mobi { get; set; }
        public string link { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
