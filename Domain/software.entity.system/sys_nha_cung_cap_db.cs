using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.entity.system
{
    public class sys_nha_cung_cap_db
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        /// <summary>
        /// 1: cá nhân
        /// 2: tổ chức
        /// 3: phòng ban
        /// 4: nhân viên
        /// 5: khách hàng
        /// 6: nhà cung cấp
        /// </summary>
        public int? hinh_thuc { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
