using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_don_vi_tinh_model
    {
        public sys_don_vi_tinh_model()
        {
            db = new sys_don_vi_tinh_db();
        }
        public sys_don_vi_tinh_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
