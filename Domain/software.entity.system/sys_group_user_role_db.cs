using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.entity.system
{
    [Table("sys_group_user_role")]
    public class sys_group_user_role_db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string id_group_user { get; set; }
        public string id_controller_role { get; set; }
        public string controller_name { get; set; }
        public string role_name { get; set; }
    }
}
