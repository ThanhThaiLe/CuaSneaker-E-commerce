using software.entity.erp;

namespace software.repo.erp.DataAccess
{
    public class erp_don_vi_van_chuyen_model
    {
        public erp_don_vi_van_chuyen_model()
        {
            db = new erp_don_vi_van_chuyen_db();
        }
        public erp_don_vi_van_chuyen_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
