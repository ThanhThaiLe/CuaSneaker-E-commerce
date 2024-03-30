using software.repo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace software.web.Controllers
{
    partial class sys_colorController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_color",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_color",
            title = "sys_color",
            url = "/sys_color_index",
            type = "item",
            translate = "NAV.sys_color",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_color;getListUse",
                        "sys_color;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_color;exportToExcel",
                        "sys_color;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_color;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_color;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_color;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_color;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_color;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_color;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_color;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_color;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_color_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_color_model item)
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
                var check = repo._context.sys_colors.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.code", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_color_model item, int index, string error)
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
                var check = repo._context.sys_colors.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã đơn vị tính " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
