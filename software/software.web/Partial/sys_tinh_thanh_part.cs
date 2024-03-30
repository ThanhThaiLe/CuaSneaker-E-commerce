using software.repo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace software.web.Controllers
{
    partial class sys_tinh_thanhController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_tinh_thanh",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_tinh_thanh",
            title = "sys_tinh_thanh",
            url = "/sys_tinh_thanh_index",
            type = "item",
            translate = "NAV.sys_tinh_thanh",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_tinh_thanh;getListUse",
                        "sys_tinh_thanh;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_tinh_thanh;exportToExcel",
                        "sys_tinh_thanh;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_tinh_thanh;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_tinh_thanh;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_tinh_thanh;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_tinh_thanh;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_tinh_thanh;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_tinh_thanh;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_tinh_thanh;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_tinh_thanh;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_tinh_thanh_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_tinh_thanh_model item)
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
                var check = repo._context.sys_tinh_thanhs.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.ten_khong_dau", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
    }
}
