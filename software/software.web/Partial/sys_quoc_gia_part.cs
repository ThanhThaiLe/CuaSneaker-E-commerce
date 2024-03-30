using software.repo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace software.web.Controllers
{
    partial class sys_quoc_giaController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_quoc_gia",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_quoc_gia",
            title = "sys_quoc_gia",
            url = "/sys_quoc_gia_index",
            type = "item",
            translate = "NAV.sys_quoc_gia",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_quoc_gia;getListUse",
                        "sys_quoc_gia;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_quoc_gia;exportToExcel",
                        "sys_quoc_gia;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_quoc_gia;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_quoc_gia;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_quoc_gia;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_quoc_gia;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_quoc_gia;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_quoc_gia;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_quoc_gia;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_quoc_gia;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_quoc_gia_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_quoc_gia_model item)
        {
            if (String.IsNullOrEmpty(item.db.ten))
            {
                ModelState.AddModelError("db.ten", "error.requied");
            }
            if (string.IsNullOrEmpty(item.db.ten_khong_dau))
            {
                ModelState.AddModelError("db.ten_khong_dau", "error.requied");
            }
            else
            {
                var check = repo._context.sys_quoc_gias.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.ten_khong_dau", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
    }
}
