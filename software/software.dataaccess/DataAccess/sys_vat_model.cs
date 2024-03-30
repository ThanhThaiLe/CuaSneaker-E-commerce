using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_vat_model
    {
        public sys_vat_model()
        {
            db = new sys_vat_db();
        }
        public sys_vat_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
