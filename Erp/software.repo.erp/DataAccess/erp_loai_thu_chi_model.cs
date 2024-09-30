using software.entity.erp;

namespace software.repo.erp.DataAccess
{
    public class erp_loai_thu_chi_model
    {
        public erp_loai_thu_chi_model()
        {
            db = new erp_loai_thu_chi_db();
        }
        public erp_loai_thu_chi_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
