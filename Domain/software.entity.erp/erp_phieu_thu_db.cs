using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_phieu_thu")]
    public class erp_phieu_thu_db : IBaseCommon
    {
        [Key]
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string unsigned_name { get; set; }
        public string ly_do_chinh_sua { get; set; }
        public int? nguon { get; set; }
        public long? id_loai_thu { get; set; }
        public string id_don_hang_ban { get; set; }
        public string id_don_hang_mua { get; set; }
        public string id_don_hang_ban_thuc_hien { get; set; }
        public DateTime? ngay_thu { get; set; }
        public int? phuong_thuc_thanh_toan { get; set; }
        public int? vi_dien_tu { get; set; }
        public long? id_tai_khoan_ngan_hang { get; set; }
        public string ma_ngan_hang { get; set; }
        public string ten_ngan_hang { get; set; }
        public string so_tai_khoan { get; set; }
        public string id_doi_tuong { get; set; }
        public string ten_doi_tuong { get; set; }
        public string ma_so_thue { get; set; }
        public string dien_thoai { get; set; }
        public string email { get; set; }
        public string dia_chi_doi_tuong { get; set; }
        public string id_quy_doi_tien_mat { get; set; }
        public string id_nguoi_duyet { get; set; }
        public bool? is_dinh_khoan { get; set; }
        public string tai_khoan_co { get; set; }
        public string tai_khoan_no { get; set; }
        public string doi_tuong_co { get; set; }
        public string doi_tuong_no { get; set; }
        public decimal? so_tien { get; set; }
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
