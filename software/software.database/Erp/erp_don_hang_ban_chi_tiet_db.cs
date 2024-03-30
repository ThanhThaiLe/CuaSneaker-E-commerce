using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("erp_don_hang_ban_chi_tiet")]
    public class erp_don_hang_ban_chi_tiet_db : IBaseCommon
    {
        public long id { get; set; }
        public long? id_don_hang { get; set; }
        public string id_san_pham { get; set; }
        public string id_size { get; set; }
        public long id_color { get; set; }
        public decimal? don_gia { get; set; }
        public int? so_luong { get; set; }
        public decimal? thanh_tien_thue { get; set; }
        public decimal? thanh_tien_chiet_khau { get; set; }
        public decimal? thanh_tien_truoc_thue { get; set; }
        public decimal? thanh_tien_sau_thue { get; set; }
        public int? gia_tri_chiet_khau { get; set; }
        public int? gia_tri_vat { get; set; }
        public long? id_vat { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
