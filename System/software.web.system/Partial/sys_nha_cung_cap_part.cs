using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_nha_cung_capController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_nha_cung_cap",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_nha_cung_cap",
            title = "sys_nha_cung_cap",
            url = "/sys_nha_cung_cap_index",
            type = "item",
            translate = "NAV.sys_nha_cung_cap",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_nha_cung_cap;getListUse",
                        "sys_nha_cung_cap;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_nha_cung_cap;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_nha_cung_cap;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_nha_cung_cap;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_nha_cung_cap;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_nha_cung_cap;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_nha_cung_cap;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_nha_cung_cap;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_nha_cung_cap;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_nha_cung_cap;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_nha_cung_cap_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_nha_cung_cap_model item)
        {
            if (String.IsNullOrEmpty(item.db.name))
            {
                ModelState.AddModelError("db.name", "error.requied");
            }
            if (String.IsNullOrEmpty(item.db.code))
            {
                ModelState.AddModelError("db.code", "error.requied");
            }
            else
            {
                var check = repo._context.sys_nha_cung_caps.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.code", "error.existed");
                }
            }
            return ModelState.IsValid;
        }

        private string CheckErrorImport(sys_nha_cung_cap_model item, int index, string error)
        {
            if (string.IsNullOrEmpty(item.db.name))
            {
                error += "Lỗi tại dòng : " + index + " tên nhãn hiệu chưa được nhập <br/>";
            }
            if (string.IsNullOrEmpty(item.db.code))
            {
                error += "Lỗi tại dòng : " + index + " mã nhãn hiệu chưa được nhập <br/>";
            }
            else
            {
                var check = repo._context.sys_nha_cung_caps.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã nhãn hiệu " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
