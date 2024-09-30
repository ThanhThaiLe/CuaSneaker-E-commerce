using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_hoa_don_ban_hang_chi_tiet")]
    public class erp_hoa_don_ban_hang_chi_tiet_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        /// <summary>
        /// đơn hàng bán
        /// </summary>
        public string id_don_hang_ban { get; set; }
        /// <summary>
        /// 1: bán lẻ
        /// 2: bán buôn
        /// </summary>
        public int? loai_hoa_don { get; set; }
        public string id_hoa_don_ban { get; set; }
        public string id_mat_hang { get; set; }
        public long? id_don_vi_tinh { get; set; }
        public int? so_luong { get; set; }
        public decimal? don_gia { get; set; }
        public decimal? thanh_tien_truoc_thue { get; set; }
        public decimal? thanh_tien_thue { get; set; }
        public long? id_vat { get; set; }
        public int? gia_tri_vat { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
