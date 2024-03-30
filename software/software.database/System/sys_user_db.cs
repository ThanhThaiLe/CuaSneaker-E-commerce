using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("sys_user")]
    public class sys_user_db
    {
        public string id { get; set; }
        /// <summary>
        /// 1: admin 
        /// 2: user
        /// </summary>
        public int? type { get; set; }
        public int? phuong_thuc_thanh_toan { get; set; }
        public string full_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string token_reset_pass { get; set; }
        public DateTime? expiration_date_reset_pass { get; set; }
        public string id_department { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        /// <summary>
        /// 1: đang sử dụng
        /// 2: ngưng sử dụng
        /// 3: đang đợi xác nhận mail
        /// </summary>
        public int? status_del { get; set; }
    }
}
