using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("sys_file_upload")]
    public class sys_file_upload_db : IBaseCommon
    {
        public long id { get; set; }
        public string controller { get; set; }
        public string id_parent { get; set; }
        public string file_type { get; set; }
        public string file_name { get; set; }
        public long file_size { get; set; }
        public string file_path { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
