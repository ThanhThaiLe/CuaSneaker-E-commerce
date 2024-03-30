using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_quan_huyen_model
    {
        public sys_quan_huyen_model()
        {
            db = new sys_quan_huyen_db();
        }
        public sys_quan_huyen_db db { get; set; }
        public string tinh_thanh { get; set; }
        public string quoc_gia { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
