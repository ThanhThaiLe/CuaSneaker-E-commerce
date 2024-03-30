using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_template_mail_model
    {
        public sys_template_mail_model()
        {
            db = new sys_template_mail_db();
        }
        public sys_template_mail_db db { get; set; }
        public string type_name_mail { get; set; }
        public string type_code_mail { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
