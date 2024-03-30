using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_tag_user_model
    {
        public sys_tag_user_model()
        {
            db = new sys_tag_user_db();
        }
        public sys_tag_user_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
