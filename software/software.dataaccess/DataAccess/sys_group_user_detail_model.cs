namespace software.repo.DataAccess
{
    public class sys_group_user_detail_model
    {
        public string user_name { get; set; }
        public string user_id { get; set; }
        public string department_name { get; set; }
        public string position_name { get; set; }
        public bool? isCheck { get; set; }
        public int? type_user { get; set; }
        public bool? is_system { get; set; }
    }
}
