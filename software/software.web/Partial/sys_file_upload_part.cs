using System.Collections.Generic;

namespace software.web.Controllers
{
    partial class sys_file_uploadController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_file_upload",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_file_upload",
            title = "sys_file_upload",
            url = "/sys_file_upload_index",
            type = "item",
            translate = "NAV.sys_file_upload",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_file_upload;upload_file",
                        "sys_file_upload;update_status",
                        "sys_file_upload;DataHandler",
                        "sys_file_upload;get_list_file",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_file_upload;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_file_upload;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_file_upload;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_file_upload;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_file_upload;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_file_upload;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_file_upload;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_file_upload;DataHandler",
                    }
                },
            }
        };
    }
}
