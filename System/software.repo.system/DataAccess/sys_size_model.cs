using software.entity.system;
namespace software.repo.DataAccess
{
    public class sys_size_model
    {
        public sys_size_model()
        {
            db = new sys_size_db();
        }
        public sys_size_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
