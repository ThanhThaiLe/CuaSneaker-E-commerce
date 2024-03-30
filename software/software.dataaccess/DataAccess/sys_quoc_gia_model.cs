using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_quoc_gia_model
    {
        public sys_quoc_gia_model()
        {
            db = new sys_quoc_gia_db();
        }
        public sys_quoc_gia_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
