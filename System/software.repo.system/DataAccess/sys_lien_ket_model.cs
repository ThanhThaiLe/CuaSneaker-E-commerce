using software.entity.system;
namespace software.repo.DataAccess
{
    public class sys_lien_ket_model
    {
        public sys_lien_ket_model()
        {
            db = new sys_lien_ket_db();
        }
        public sys_lien_ket_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
