using software.entity.system;

namespace software.repo.DataAccess
{
    public class sys_banner_model
    {
        public sys_banner_model()
        {
            db = new sys_banner_db();
        }
        public sys_banner_db db { get; set; }
        public string ten_loai_banner { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
    public class portal_banner_model
    {
        public long id { get; set; }
        public int id_type { get; set; }
        public string image_web { get; set; }
        public string image_mobi { get; set; }
        public string link { get; set; }
    }
}
