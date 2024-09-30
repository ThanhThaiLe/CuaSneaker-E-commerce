using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.entity.system
{
    [Table("sys_group_user_detail")]
    public class sys_group_user_detail_db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string id_group_user { get; set; }
        public string user_id { get; set; }
    }
}
