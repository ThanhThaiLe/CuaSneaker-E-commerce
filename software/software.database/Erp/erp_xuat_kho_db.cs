using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("erp_xuat_kho")]
    public class erp_xuat_kho_db : IBaseCommon
    {
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long? loai_xuat { get; set; }
        public long? id_kho { get; set; }
        public DateTime? ngay_xuat { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
