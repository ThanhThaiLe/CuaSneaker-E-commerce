using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("erp_don_hang_mua_chi_tiet")]
    public class erp_don_hang_mua_chi_tiet_db : IBaseCommon
    {
        public long id { get; set; }
        public long? id_don_hang { get; set; }
        public long id_san_pham { get; set; }
        public long so_luong { get; set; }
        public decimal? don_gia { get; set; }
        public decimal? thanh_tien { get; set; }
        public int? chiet_khau { get; set; }
        public long? id_chiet_khau { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
