using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_loai_nhap_xuat")]
    public class erp_loai_nhap_xuat_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        /// <summary>
        /// 1: nhập
        /// 2: xuất
        /// </summary>
        public int? loai_nhap_xuat { get; set; }
        /// <summary>
        /// 1: Đơn hàng bán
        /// 2: Đơn hàng mua
        /// </summary>
        public int? nguon { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
