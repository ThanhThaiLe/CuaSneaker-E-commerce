using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_file_upload_model
    {
        public sys_file_upload_model()
        {
            db = new sys_file_upload_db();
        }
        public sys_file_upload_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
