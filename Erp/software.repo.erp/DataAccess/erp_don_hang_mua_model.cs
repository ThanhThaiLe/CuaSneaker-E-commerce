using software.entity.erp;

namespace software.repo.erp.DataAccess
{
    public class erp_don_hang_mua_model
    {
        public erp_don_hang_mua_model()
        {
            db = new erp_don_hang_mua_db();
            list_detail = new List<erp_don_hang_mua_chi_tiet_model>();
        }
        public erp_don_hang_mua_db db { get; set; }
        public List<erp_don_hang_mua_chi_tiet_model> list_detail { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
