using software.entity.system;
namespace software.repo.DataAccess
{
    public class sys_tinh_thanh_model
    {
        public sys_tinh_thanh_model()
        {
            db = new sys_tinh_thanh_db();
        }
        public sys_tinh_thanh_db db { get; set; }
        public string quoc_gia { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
