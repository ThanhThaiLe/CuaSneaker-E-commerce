using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("sys_san_pham")]
    public class sys_san_pham_db : IBaseCommon
    {
        public string id { get; set; }
        public long? id_loai_san_pham { get; set; }
        public long? id_nhan_hieu { get; set; }
        public long? id_don_vi_tinh { get; set; }
        public string ten_san_pham { get; set; }
        public string ma_san_pham { get; set; }
        public string hinh_anh { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
        public string note { get; set; }
    }
}
