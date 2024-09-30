using software.entity.system;

namespace software.repo.DataAccess
{
    public class sys_loai_san_pham_model
    {
        public sys_loai_san_pham_model()
        {
            db = new sys_loai_san_pham_db();
        }
        public sys_loai_san_pham_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
