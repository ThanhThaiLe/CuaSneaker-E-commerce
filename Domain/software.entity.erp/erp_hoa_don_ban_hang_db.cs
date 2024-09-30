using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.erp
{
    [Table("erp_hoa_don_ban_hang")]
    public class erp_hoa_don_ban_hang_db : IBaseCommon
    {
        [Key]
        public string id { get; set; }
        /// <summary>
        /// đơn hàng bán
        /// </summary>
        public string id_don_hang_ban { get; set; }
        public string so_seri { get; set; }
        public string so_hoa_don { get; set; }
        public int? loai_hoa_don { get; set; }
        public DateTime? ngay_ghi_hoa_don { get; set; }
        /// <summary>
        /// 1: tạo mới
        /// 2: phát hành hóa đơn
        /// 3: hủy hóa đơn
        /// 4: thay thế hóa đơn
        /// </summary>
        public int? trang_thai_phat_sinh { get; set; }
        public string id_hoa_don_thay_the { get; set; }
        public int? hinh_thuc_doi_tuong { get; set; }
        public string id_doi_tuong { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
