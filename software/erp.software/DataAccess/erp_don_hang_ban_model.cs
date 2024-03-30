
using software.database.System;
using System.Collections.Generic;

namespace software.repo.erp.DataAccess
{
    public class erp_don_hang_ban_model
    {
        public erp_don_hang_ban_model()
        {
            db = new erp_don_hang_ban_db();
            list_detail = new List<erp_don_hang_ban_chi_tiet_model>();
        }
        public erp_don_hang_ban_db db { get; set; }
        public List<erp_don_hang_ban_chi_tiet_model> list_detail { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
        public string tinh_thanh_khach_hang_nhan { get; set; }
        public string quan_huyen_khach_hang_nhan { get; set; }
        public string tinh_thanh_khach_hang_dat { get; set; }
        public string quan_huyen_khach_hang_dat { get; set; }
        public string ten_ngan_hang { get; set; }
        public string so_tai_khoan { get; set; }
    }
}
