using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.system
{
    [Table("sys_template_mail")]
    public class sys_template_mail_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long? id_type { get; set; }
        public string name { get; set; }
        public string template { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
