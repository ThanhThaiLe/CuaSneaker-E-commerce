using software.database.System;
using System;
using System.Collections.Generic;

namespace software.web.Controllers
{
    partial class sys_tag_userController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_tag_user",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_tag_user",
            title = "sys_tag_user",
            url = "/sys_tag_user_index",
            type = "item",
            translate = "NAV.sys_tag_user",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_tag_user;getListUse",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_tag_user;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_tag_user;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_tag_user;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_tag_user;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_tag_user;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_tag_user;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_tag_user;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_tag_user;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_tag_user_db item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_tag_user_db item)
        {
            if (String.IsNullOrEmpty(item.title))
            {
                ModelState.AddModelError("db.fullname", "error.requied");
            }
            return ModelState.IsValid;
        }
    }
}
