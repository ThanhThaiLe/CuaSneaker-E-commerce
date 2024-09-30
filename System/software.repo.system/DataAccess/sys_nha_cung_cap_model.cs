using software.entity.system;
namespace software.repo.DataAccess
{
    public class sys_nha_cung_cap_model
    {
        public sys_nha_cung_cap_model()
        {
            db = new sys_nha_cung_cap_db();
        }
        public sys_nha_cung_cap_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
