using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_sizeController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_size",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_size",
            title = "sys_size",
            url = "/sys_size_index",
            type = "item",
            translate = "NAV.sys_size",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_size;getListUse",
                        "sys_size;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_size;exportToExcel",
                        "sys_size;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_size;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_size;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_size;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_size;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_size;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_size;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_size;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_size;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_size_model item)
        {
            return checkModelStateCreateEdit(ActionEnumForm.create, item);
        }
        private bool checkModelStateCreateEdit(ActionEnumForm action, sys_size_model item)
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
                var check = repo._context.sys_sizes.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.code", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_size_model item, int index, string error)
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
                var check = repo._context.sys_sizes.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã đơn vị tính " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
