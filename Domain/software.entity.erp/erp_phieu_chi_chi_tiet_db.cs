using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_phieu_chi_chi_tiet")]
    public class erp_phieu_chi_chi_tiet_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string id_phieu_chi { get; set; }
        public string noi_dung { get; set; }
        public decimal? so_tien { get; set; }
        public bool? is_dinh_khoan { get; set; }
        public string tai_khoan_co { get; set; }
        public string tai_khoan_no { get; set; }
        public string doi_tuong_co { get; set; }
        public string doi_tuong_no { get; set; }
        public DateTime? ngay_chi { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
