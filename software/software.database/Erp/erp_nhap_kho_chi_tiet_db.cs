using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("erp_nhap_kho_chi_tiet")]
    public class erp_nhap_kho_chi_tiet_db : IBaseCommon
    {
        public long id { get; set; }
        public long? id_phieu_nhap { get; set; }
        public long? id_san_pham { get; set; }
        public long so_luong { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
