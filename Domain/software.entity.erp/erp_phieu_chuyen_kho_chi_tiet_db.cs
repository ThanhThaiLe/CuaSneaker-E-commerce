using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_phieu_chuyen_kho_chi_tiet")]
    public class erp_phieu_chuyen_kho_chi_tiet_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string id_phieu_xuat_kho { get; set; }
        public string id_mat_hang { get; set; }
        public long? id_loai_mat_hang { get; set; }
        public string ma_vach { get; set; }
        public long? id_don_vi_tinh { get; set; }
        public int? so_luong { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
