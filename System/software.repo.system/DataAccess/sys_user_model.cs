using software.entity.system;
namespace software.repo.DataAccess
{
    public class sys_user_model
    {
        public sys_user_model()
        {
            db = new sys_user_db();
        }
        public sys_user_db db { get; set; }
        public int? show_captcha { get; set; }
        public string captcha { get; set; }
        public string password { get; set; }
        public string reset_password { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
    public class sys_user_register_model
    {
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string captcha { get; set; }
        public bool? agreements { get; set; }
    }
    public class sys_user_authentication_model
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string company { get; set; }
        public int show_captcha { get; set; }
        public string captcha { get; set; }
    }
    public class sys_user_login_model
    {
        public string id { get; set; }
        public string avatar_path { get; set; }
        public string last_name { get; set; }
    }

}
