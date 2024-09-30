using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.system
{
    [Table("sys_thong_tin_website")]
    public class sys_thong_tin_website_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string image_logo { get; set; }
        public string image_footer { get; set; }
        public string dia_chi { get; set; }
        public string so_dien_thoai { get; set; }
        public string email { get; set; }
        public string link_facebook { get; set; }
        public string link_youtube { get; set; }
        public string link_linkedin { get; set; }
        public string link_instagram { get; set; }
        public string image_facebook { get; set; }
        public string image_youtube { get; set; }
        public string image_linkedin { get; set; }
        public string image_instagram { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
