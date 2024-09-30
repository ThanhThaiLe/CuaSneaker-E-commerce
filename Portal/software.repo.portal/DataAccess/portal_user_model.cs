namespace software.repo.DataAccess
{
    public class portal_user_model
    {
        public portal_user_model()
        {
        }
        public string id { get; set; }
        public string full_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public int? show_captcha { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string captcha { get; set; }
        public string password { get; set; }
        public string reset_password { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        /// <summary>
        /// 1: admin 
        /// 2: user
        /// </summary>
        public int? type { get; set; }
        /// <summary>
        /// 1: đang sử dụng
        /// 2: ngưng sử dụng
        /// 3: đang đợi xác nhận mail
        /// </summary>
        public int? status_del { get; set; }
    }
    public class portal_user_register_model
    {
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string captcha { get; set; }
        public bool? agreements { get; set; }
    }
    public class portal_user_authentication_model
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string company { get; set; }
        public int show_captcha { get; set; }
        public string captcha { get; set; }
    }
    public class portal_user_login_model
    {
        public string id { get; set; }
        public string avatar_path { get; set; }
        public string last_name { get; set; }
    }

}
