using software.database.System;
using System.Collections.Generic;

namespace software.repo.DataAccess
{
    public class sys_san_pham_model
    {
        public sys_san_pham_model()
        {
            db = new sys_san_pham_db();
            list_file = new List<sys_file_upload_model>();
            list_detail = new List<sys_san_pham_chi_tiet_model>();
        }
        public sys_san_pham_db db { get; set; }
        public List<sys_file_upload_model> list_file { get; set; }
        public List<sys_san_pham_chi_tiet_model> list_detail { get; set; }
        public string ten_nhan_hieu { get; set; }
        public string ten_loai_san_pham { get; set; }
        public string ten_don_vi_tinh { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
    }
}
