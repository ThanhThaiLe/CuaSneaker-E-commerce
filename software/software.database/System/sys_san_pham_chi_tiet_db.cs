using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("sys_san_pham_chi_tiet")]
    public class sys_san_pham_chi_tiet_db : IBaseCommon
    {
        public long id { get; set; }
        public string id_san_pham { get; set; }
        public string id_size { get; set; }
        public long? id_color { get; set; }
        public string hinh_anh { get; set; }
        public string mo_ta { get; set; }
        public decimal? gia_ban { get; set; }
        public bool? is_noi_bac { get; set; }
        public bool? is_khuyen_mai { get; set; }
        public string qr_image { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
        public string note { get; set; }
    }
}
