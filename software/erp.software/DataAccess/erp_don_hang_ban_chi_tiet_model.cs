
using software.database.System;

namespace software.repo.erp.DataAccess
{
    public class erp_don_hang_ban_chi_tiet_model
    {
        public erp_don_hang_ban_chi_tiet_model()
        {
            db = new erp_don_hang_ban_chi_tiet_db();
        }
        public erp_don_hang_ban_chi_tiet_db db { get; set; }
        public string create_name { get; set; }
        public string update_name { get; set; }
        public string ma_san_pham { get; set; }
        public string ten_san_pham { get; set; }
        public string ten_nhan_hieu { get; set; }
        public string ten_loai_san_pham { get; set; }
        public string color_code { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string size_code { get; set; }
        public string gia_ban { get; set; }
        public string ten_don_vi_tinh { get; set; }
        public int? ty_le_vat { get; set; }
    }
}
