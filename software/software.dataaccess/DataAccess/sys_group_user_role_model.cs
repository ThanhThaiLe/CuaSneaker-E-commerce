using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_group_user_role_model
    {
        public sys_group_user_role_model()
        {
            db = new sys_group_user_role_db();
        }
        public string user_name { get; set; }
        public sys_group_user_role_db db { get; set; }
    }
}
