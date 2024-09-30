using software.entity.system;
namespace software.repo.DataAccess
{
    public class sys_san_pham_chi_tiet_model
    {
        public sys_san_pham_chi_tiet_model()
        {
            db = new sys_san_pham_chi_tiet_db();
            list_file = new List<sys_file_upload_db>();
            list_code_size = new List<string>();
            list_id_size = new List<long>();
        }
        public List<sys_file_upload_db> list_file { get; set; }
        public sys_san_pham_chi_tiet_db db { get; set; }
        public string ma_san_pham { get; set; }
        public string ten_san_pham { get; set; }
        public string size { get; set; }
        public List<string> list_code_size { get; set; }
        public List<long> list_id_size { get; set; }
        public string color { get; set; }
        public string color_code { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
