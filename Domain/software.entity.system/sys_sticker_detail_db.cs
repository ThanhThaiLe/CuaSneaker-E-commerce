using domain.services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace software.entity.system
{
    [Table("sys_sticker_detail")]
    public class sys_sticker_detail_db : IBaseCommon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string file_path { get; set; }
        public long? file_size { get; set; }
        public string file_type { get; set; }
        public long? id_sticker { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
