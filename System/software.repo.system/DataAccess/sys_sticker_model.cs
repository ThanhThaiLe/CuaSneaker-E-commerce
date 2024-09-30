using software.entity.system;
namespace software.repo.DataAccess
{
    public class sys_sticker_model
    {
        public sys_sticker_model()
        {
            db = new sys_sticker_db();
        }
        public sys_sticker_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
