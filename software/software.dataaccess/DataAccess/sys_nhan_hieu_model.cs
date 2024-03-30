using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_nhan_hieu_model
    {
        public sys_nhan_hieu_model()
        {
            db = new sys_nhan_hieu_db();
        }
        public sys_nhan_hieu_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
