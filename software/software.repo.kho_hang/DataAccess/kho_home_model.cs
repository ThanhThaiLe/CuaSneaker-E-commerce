namespace software.repo.kho.DataAccess
{
    public class kho_home_model
    {
    }
    public class portal_san_pham_model
    {
        public string id { get; set; }
        public string ten_san_pham { get; set; }
        public string ma_san_pham { get; set; }
        public string loai_san_pham { get; set; }
        public string mo_ta { get; set; }
        public string hinh_anh { get; set; }
        public long? id_loai_san_pham { get; set; }
        public bool? is_khuyen_mai { get; set; }
        public bool? is_noi_bac { get; set; }
        public decimal? gia_ban { get; set; }
        public decimal? gia_khuyen_mai { get; set; }
    }
}
