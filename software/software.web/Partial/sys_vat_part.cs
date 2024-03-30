using software.repo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace software.web.Controllers
{
    partial class sys_vatController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_vat",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_vat",
            title = "sys_vat",
            url = "/sys_vat_index",
            type = "item",
            translate = "NAV.sys_vat",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_vat;getListUse",
                        "sys_vat;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_vat;exportToExcel",
                        "sys_vat;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_vat;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_vat;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_vat;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_vat;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_vat;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_vat;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_vat;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_vat;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_vat_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_vat_model item)
        {
            if (item.db.value == null)
            {
                ModelState.AddModelError("db.value", "error.requied");
            }
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
                var check = repo._context.sys_vats.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.code", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_vat_model item, int index, string error)
        {
            if (item.db.value == null)
            {
                error += "Lỗi tại dòng : " + index + " tên đơn vị tính chưa được nhập <br/>";
            }
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
                var check = repo._context.sys_vats.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã đơn vị tính " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
