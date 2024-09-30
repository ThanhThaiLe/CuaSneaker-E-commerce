using software.entity.erp;

namespace software.repo.erp.DataAccess
{
    public class erp_loai_nhap_xuat_model
    {
        public erp_loai_nhap_xuat_model()
        {
            db = new erp_loai_nhap_xuat_db();
        }
        public erp_loai_nhap_xuat_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
