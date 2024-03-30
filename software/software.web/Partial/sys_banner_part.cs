using software.repo.DataAccess;
using System;
using System.Collections.Generic;

namespace software.web.Controllers
{
    partial class sys_bannerController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_banner",
            icon = "heroicons_outline:home",
            icon_image = "../assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_banner",
            title = "sys_banner",
            url = "/sys_banner_index",
            type = "item",
            translate = "NAV.sys_banner",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_banner;getListUse",
                        "sys_banner;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_banner;ImportFormExcel",
                        "sys_banner;exportToExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_banner;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_banner;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_banner;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_banner;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_banner;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_banner;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_banner;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_banner;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_banner_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_banner_model item)
        {
            if (String.IsNullOrEmpty(item.db.id_type))
            {
                ModelState.AddModelError("db.id_type", "error.requied");
            }
            if (String.IsNullOrEmpty(item.db.image_mobi))
            {
                ModelState.AddModelError("db.image_mobi", "error.requied");
            }
            if (String.IsNullOrEmpty(item.db.image_web))
            {
                ModelState.AddModelError("db.image_web", "error.requied");
            }
            return ModelState.IsValid;
        }
    }
}
