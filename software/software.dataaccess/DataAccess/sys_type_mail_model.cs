using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_type_mail_model
    {
        public sys_type_mail_model()
        {
            db = new sys_type_mail_db();
        }
        public sys_type_mail_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
