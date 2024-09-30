using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_loai_thu_chi")]
    public class erp_loai_thu_chi_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        /// <summary>
        /// 1: thu
        /// 2: chi
        /// </summary>
        public int? loai { get; set; }
        public bool? is_system { get; set; }
        public int? stt { get; set; }
        public string ma_tai_khoan_no_tien_mat { get; set; }
        public string ma_tai_khoan_co_tien_mat { get; set; }
        public string ma_tai_khoan_co_chuyen_khoan { get; set; }
        public string ma_tai_khoan_no_chuyen_khoan { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
