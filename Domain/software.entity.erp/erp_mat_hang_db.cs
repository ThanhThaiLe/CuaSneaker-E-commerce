using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_mat_hang")]
    public class erp_mat_hang_db : IBaseCommon
    {
        [Key]
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string xuat_xu { get; set; }
        public long? id_nhan_hieu { get; set; }
        public int? thuoc_tinh { get; set; }
        public string ma_vach { get; set; }
        public string unsigned_name { get; set; }
        public string tien_te { get; set; }
        public string barcode { get; set; }
        public string qrcode { get; set; }
        public string don_vi_tinh_quy_doi { get; set; }
        public long? id_loai_san_pham { get; set; }
        public long? id_don_vi_tinh { get; set; }
        public decimal? gia_ban_le { get; set; }
        public decimal? gia_ban_si { get; set; }
        public decimal? gia_von { get; set; }
        public decimal? he_so_quy_doi { get; set; }
        public int? gia_tri_vat { get; set; }
        public int? ty_le_chiet_khau { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
