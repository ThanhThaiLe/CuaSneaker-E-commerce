using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_xuat_kho")]
    public class erp_xuat_kho_db : IBaseCommon
    {
        [Key]
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string unsigned_name { get; set; }
        public string id_don_hang_ban_thuc_hien { get; set; }
        public string id_don_hang_ban { get; set; }
        public string id_don_hang_mua { get; set; }
        public int? nguon { get; set; }
        public int? hinh_thuc_doi_tuong { get; set; }

        public string id_doi_tuong { get; set; }
        public string ten_doi_tuong { get; set; }
        public string ma_so_thue { get; set; }
        public string dien_thoai { get; set; }
        public string email { get; set; }
        public string dia_chi { get; set; }
        public long? id_loai_nhap { get; set; }
        public long? id_kho { get; set; }
        public DateTime? ngay_xuat { get; set; }
        public string id_phieu_chuyen_kho { get; set; }
        public bool? is_sinh_tu_dong { get; set; }
        public int? loai { get; set; }
        public string so_phieu { get; set; }

        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
