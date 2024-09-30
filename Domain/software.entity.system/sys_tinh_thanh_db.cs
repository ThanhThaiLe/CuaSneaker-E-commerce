using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.system
{
    [Table("sys_tinh_thanh")]
    public class sys_tinh_thanh_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long? id_quoc_gia { get; set; }
        public string ten { get; set; }
        public string ten_khong_dau { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
