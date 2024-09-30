using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace software.entity.erp
{
    [Table("erp_don_hang_mua_chi_tiet")]
    public class erp_don_hang_mua_chi_tiet_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long? id_don_hang { get; set; }
        public long? id_mat_hang { get; set; }
        public string ten_mat_hang { get; set; }
        public string ma_mat_hang { get; set; }
        public long? id_nhan_hieu { get; set; }
        public long? id_don_vi_tinh { get; set; }
        public long so_luong { get; set; }
        public decimal? don_gia { get; set; }
        public decimal? thanh_tien_sau_chiet_khau { get; set; }
        public decimal? thanh_tien_chiet_khau { get; set; }
        public decimal? thanh_tien_truoc_chiet_khau { get; set; }
        public int? chiet_khau { get; set; }
        public long? id_chiet_khau { get; set; }
        public long? id_voucher { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
