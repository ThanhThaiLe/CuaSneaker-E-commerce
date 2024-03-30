using software.common.Model;
using software.repo.DataAccess;
using System.Collections.Generic;

namespace software.repo.portal.DataAccess
{
    public class portal_home_model
    {
    }
    public class portal_payment_model
    {
        public portal_payment_model()
        {
            list_san_pham_detail = new List<portal_san_pham_chi_tiet_model>();
        }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string so_dien_thoai { get; set; }
        public string about { get; set; }
        public string tinh_thanh { get; set; }
        public string quan_huyen { get; set; }
        public string dia_chi { get; set; }
        public List<portal_san_pham_chi_tiet_model> list_san_pham_detail { get; set; }
    }
    public class portal_san_pham_model
    {
        public portal_san_pham_model()
        {
            list_san_pham_detail = new List<portal_san_pham_chi_tiet_model>();
            list_color = new List<sys_common_number_model>();
        }
        public string id { get; set; }
        public string ten_san_pham { get; set; }
        public string ma_san_pham { get; set; }
        public string loai_san_pham { get; set; }
        public string nhan_hieu { get; set; }
        public string mo_ta { get; set; }
        public string hinh_anh { get; set; }
        public long? id_loai_san_pham { get; set; }
        public bool? is_khuyen_mai { get; set; }
        public bool? is_noi_bac { get; set; }
        public decimal? gia_ban { get; set; }
        public decimal? gia_khuyen_mai { get; set; }
        public List<portal_san_pham_chi_tiet_model> list_san_pham_detail { get; set; }
        public List<sys_common_number_model> list_color { get; set; }
    }
    public class portal_san_pham_chi_tiet_model
    {
        public portal_san_pham_chi_tiet_model()
        {
            list_size = new List<sys_common_number_model>();
            list_file = new List<sys_file_upload_model>();
        }
        public long? id { get; set; }
        public string link { get; set; }
        public string id_san_pham { get; set; }
        public string id_size { get; set; }
        public long? id_color { get; set; }
        public decimal? gia_ban { get; set; }
        public string hinh_anh { get; set; }
        public string ma_san_pham { get; set; }
        public string mo_ta { get; set; }
        public string ten_san_pham { get; set; }
        public string size { get; set; }
        public string size_code { get; set; }
        public string color { get; set; }
        public string color_code { get; set; }
        public List<sys_file_upload_model> list_file { get; set; }
        public List<sys_common_number_model> list_size { get; set; }
    }
}
