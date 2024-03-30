using software.repo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace software.web.Controllers
{
    partial class sys_khoController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_kho",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_kho",
            title = "sys_kho",
            url = "/sys_kho_index",
            type = "item",
            translate = "NAV.sys_kho",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_kho;getListUse",
                        "sys_kho;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_kho;exportToExcel",
                        "sys_kho;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_kho;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_kho;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_kho;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_kho;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_kho;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_kho;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_kho;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_kho;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_kho_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_kho_model item)
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
                var check = repo._context.sys_khos.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.code", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_kho_model item, int index, string error)
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
                var check = repo._context.sys_khos.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã đơn vị tính " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
