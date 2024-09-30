using software.entity.system;
namespace software.repo.DataAccess
{
    public class sys_group_user_model
    {
        public sys_group_user_model()
        {

        }
        public string ten_nguoi_cap_nhap { get; set; }
        public string createby_name { get; set; }
        public int? count_user { get; set; }
        public string updateby_name { get; set; }
        public sys_group_user_db db { get; set; }
        public List<sys_group_user_detail_model> list_item { get; set; }
        public List<sys_group_user_role_model> list_role { get; set; }
    }
}
