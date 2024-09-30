using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.system
{
    [Table("sys_tai_san_lich_su_cap_nhat")]
    public class sys_tai_san_lich_su_cap_nhat_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long? id_tai_san { get; set; }
        /// <summary>
        /// 1 Cấp phát
        /// 2 Thu hồi
        /// </summary>
        public int? loai { get; set; }
        /// <summary>
        /// -1 Tất cả nhân viên
        /// </summary>
        public string id_nhan_vien { get; set; }
        /// <summary>
        ///  Phòng ban
        /// </summary>
        public string id_phong_ban { get; set; }
        public int? so_luong { get; set; }
        public string ly_do { get; set; }
        public string dia_diem_ban_giao { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }

    }
}
