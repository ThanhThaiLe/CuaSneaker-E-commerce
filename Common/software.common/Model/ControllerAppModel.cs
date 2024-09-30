using System.Collections.Generic;

namespace software.common.Model
{
    public class ControllerAppModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public string icon_image { get; set; }
        public string translate { get; set; }
        public string type { get; set; }
        public string controller { get; set; }
        public int? type_user { get; set; }
        public string image { get; set; }
        public string module { get; set; }
        public string is_badge { get; set; }
        public string is_approval { get; set; }
        public bool is_show_all_user { get; set; }
        public List<ControllerRoleModel> list_role { get; set; } = new List<ControllerRoleModel>();
        public List<string> list_controller_action_public { get; set; } = new List<string>();
        public List<string> list_public_Non_action_controller { get; set; } = new List<string>();
    }
    public class ControllerRoleModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> list_controller_action { get; set; } = new List<string>();

    }
}
