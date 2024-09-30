using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.system
{
    [Table("sys_tai_san")]
    public class sys_tai_san_db : IBaseCommon
    {
        [Key]
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string unsigned_name { get; set; }
        public string address { get; set; }
        public string id_doi_tuong { get; set; }
        public int? nam_san_xuat { get; set; }
        public DateTime? ngay_het_han { get; set; }
        public string serial { get; set; }
        public long? id_don_vi_tinh { get; set; }
        public string quy_cach_kich_thuoc { get; set; }
        public string xuat_xu { get; set; }
        public long? id_nhan_hieu { get; set; }
        public decimal? don_gia { get; set; }
        public int? so_luong { get; set; }
        public decimal? thanh_tien { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        /// <summary>
        /// 1: use
        /// 2: not use
        /// 3: hỏng
        /// 4: mất
        /// 5: thanh lý
        /// </summary>
        public int? status_del { get; set; }
        public DateTime? ngay_bao { get; set; }
        public string ly_do { get; set; }
        public decimal? so_tien_thanh_ly { get; set; }
        public string id_loai_tai_san { get; set; }
        public string id_phan_bo_su_dung { get; set; }
        public int? loai_khai_bao { get; set; }
        /// <summary>
        /// Khấu hao tài sản cố đinh
        /// </summary>
        public DateTime? kh_ngay_tinh_khau_hao { get; set; }
        public int? kh_so_ky_khau_hao { get; set; }
        public DateTime? kh_ngay_ket_thuc_khau_hao { get; set; }
        public decimal? kh_gia_tri_khau_hao_trong_mot_ky { get; set; }
        public decimal? kh_gia_tri_da_khau_hao { get; set; }
        public decimal? kh_gia_tri_con_lai { get; set; }
        /// <summary>
        /// Phân bổ công cụ dụng cụ
        /// </summary>

        public decimal? pb_gia_tri_phan_bo_trong_mot_ky { get; set; }
        public decimal? pb_gia_tri_da_phan_bo { get; set; }
        public decimal? pb_gia_tri_con_lai { get; set; }
        public DateTime? pb_ngay_tinh_phan_bo { get; set; }
        public int? pb_so_ky_phan_bo { get; set; }
        public DateTime? pb_ngay_ket_thuc_phan_bo { get; set; }
        /// <summary>
        /// Định khoản
        /// </summary>
        public string tai_khoan_chi_phi { get; set; }
        public string tai_khoan_nguyen_gia { get; set; }
        public string tai_khoan_khau_hao { get; set; }
        public string tai_khoan_phan_bo { get; set; }
        public string id_phieu_nhap_kho { get; set; }
        public string id_don_hang_mua { get; set; }
        public string id_phieu_nhap_kho_chi_tiet { get; set; }

    }
}
