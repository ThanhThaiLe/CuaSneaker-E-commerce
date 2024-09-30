using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_nhap_kho_chi_tiet")]
    public class erp_nhap_kho_chi_tiet_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string id_phieu_nhap { get; set; }
        public string id_mat_hang { get; set; }
        public long? id_don_vi_tinh { get; set; }
        public int? so_luong { get; set; }
        public int? don_gia { get; set; }
        public int? gia_tri { get; set; }
        public DateTime? ngay_nhap { get; set; }
        public bool? is_dinh_khoan { get; set; }
        public string tai_khoan_co { get; set; }
        public string tai_khoan_no { get; set; }
        public string doi_tuong_no { get; set; }
        public string doi_tuong_co { get; set; }
        public long? id_loai_nhap { get; set; }
        public long? id_kho { get; set; }
        public long? id_tai_san { get; set; }
        public bool? is_chuyen_tai_san { get; set; }
        public bool? is_vat { get; set; }
        public int? ty_suat_vat { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
