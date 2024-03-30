using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_kho_model
    {
        public sys_kho_model()
        {
            db = new sys_kho_db();
        }
        public sys_kho_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
