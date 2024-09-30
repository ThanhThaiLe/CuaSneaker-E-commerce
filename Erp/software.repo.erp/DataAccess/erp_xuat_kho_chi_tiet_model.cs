using software.entity.erp;

namespace software.repo.erp.DataAccess
{
    public class erp_xuat_kho_chi_tiet_model
    {
        public erp_xuat_kho_chi_tiet_model()
        {
            db = new erp_xuat_kho_chi_tiet_db();
        }
        public erp_xuat_kho_chi_tiet_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
