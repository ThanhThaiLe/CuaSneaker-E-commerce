using software.database.System;

namespace software.repo.DataAccess
{
    public class sys_user_nhan_hang_model
    {
        public sys_user_nhan_hang_model()
        {
            db = new sys_user_nhan_hang_db();
        }
        public sys_user_nhan_hang_db db { get; set; }
    }
}
