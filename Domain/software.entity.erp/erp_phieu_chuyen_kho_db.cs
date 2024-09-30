using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_phieu_chuyen_kho")]
    public class erp_phieu_chuyen_kho_db : IBaseCommon
    {
        [Key]
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string unsigned_name { get; set; }
        public string ly_do_chinh_sua { get; set; }
        public int? nguon { get; set; }

        public long? id_loai_nhap { get; set; }
        public long? id_loai_xuat { get; set; }
        public DateTime? ngay_du_kien_chuyen_di { get; set; }
        public DateTime? ngay_du_kien_nhap_ve { get; set; }
        public long? id_kho_nhap { get; set; }
        public long? id_kho_xuat { get; set; }
        public string id_phieu_nhap { get; set; }
        public string id_phieu_xuat { get; set; }
        /// <summary>
        /// 1: cá nhân
        /// 2: tổ chức
        /// </summary>
        public int? hinh_thuc_doi_tuong { get; set; }
        public string id_doi_tuong { get; set; }
        public string ten_doi_tuong { get; set; }
        public string ma_so_thue { get; set; }
        public string dien_thoai { get; set; }
        public string email { get; set; }
        public string dia_chi_doi_tuong { get; set; }

        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
