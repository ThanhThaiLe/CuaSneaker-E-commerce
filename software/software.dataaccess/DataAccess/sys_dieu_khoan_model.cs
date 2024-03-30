using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_dieu_khoan_model
    {
        public sys_dieu_khoan_model()
        {
            db = new sys_dieu_khoan_db();
        }
        public sys_dieu_khoan_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
