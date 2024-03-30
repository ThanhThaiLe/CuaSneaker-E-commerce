
using software.database.System;
using System.Collections.Generic;

namespace software.repo.erp.DataAccess
{
    public class erp_nhap_kho_model
    {
        public erp_nhap_kho_model()
        {
            db = new erp_nhap_kho_db();
            list_detail = new List<erp_nhap_kho_chi_tiet_model>();
        }
        public erp_nhap_kho_db db { get; set; }
        public List<erp_nhap_kho_chi_tiet_model> list_detail { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
