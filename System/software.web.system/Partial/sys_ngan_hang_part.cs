﻿using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_ngan_hangController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_ngan_hang",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_ngan_hang",
            title = "sys_ngan_hang",
            url = "/sys_ngan_hang_index",
            type = "item",
            translate = "NAV.sys_ngan_hang",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_ngan_hang;getListUse",
                        "sys_ngan_hang;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_ngan_hang;exportToExcel",
                        "sys_ngan_hang;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_ngan_hang;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_ngan_hang;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_ngan_hang;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_ngan_hang;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_ngan_hang;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_ngan_hang;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_ngan_hang;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_ngan_hang;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_ngan_hang_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_ngan_hang_model item)
        {
            if (String.IsNullOrEmpty(item.db.name))
            {
                ModelState.AddModelError("db.name", "error.requied");
            }
            if (string.IsNullOrEmpty(item.db.code))
            {
                ModelState.AddModelError("db.code", "error.requied");
            }
            else
            {
                var check = repo._context.sys_ngan_hangs.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.code", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_ngan_hang_model item, int index, string error)
        {
            if (string.IsNullOrEmpty(item.db.name))
            {
                error += "Lỗi tại dòng : " + index + " tên đơn vị tính chưa được nhập <br/>";
            }

            if (string.IsNullOrEmpty(item.db.code))
            {
                error += "Lỗi tại dòng : " + index + " mã đơn vị tính chưa được nhập <br/>";
            }
            else
            {
                var check = repo._context.sys_ngan_hangs.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã đơn vị tính " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
