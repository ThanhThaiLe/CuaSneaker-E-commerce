using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_ngan_hang_model
    {
        public sys_ngan_hang_model()
        {
            db = new sys_ngan_hang_db();
        }
        public sys_ngan_hang_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
