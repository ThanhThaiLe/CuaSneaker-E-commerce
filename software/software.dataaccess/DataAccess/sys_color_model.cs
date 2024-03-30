using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_color_model
    {
        public sys_color_model()
        {
            db = new sys_color_db();
        }
        public sys_color_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
