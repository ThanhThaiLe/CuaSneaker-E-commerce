using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_lien_ketController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_lien_ket",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_lien_ket",
            title = "sys_lien_ket",
            url = "/sys_lien_ket_index",
            type = "item",
            translate = "NAV.sys_lien_ket",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_lien_ket;getListUse",
                        "sys_lien_ket;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_lien_ket;exportToExcel",
                        "sys_lien_ket;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_lien_ket;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_lien_ket;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_lien_ket;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_lien_ket;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_lien_ket;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_lien_ket;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_lien_ket;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_lien_ket;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_lien_ket_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_lien_ket_model item)
        {
            if (String.IsNullOrEmpty(item.db.name))
            {
                ModelState.AddModelError("db.name", "error.requied");
            }
            if (String.IsNullOrEmpty(item.db.link))
            {
                ModelState.AddModelError("db.link", "error.requied");
            }
            if (string.IsNullOrEmpty(item.db.code))
            {
                ModelState.AddModelError("db.code", "error.requied");
            }
            else
            {
                var check = repo._context.sys_lien_kets.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.code", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_lien_ket_model item, int index, string error)
        {
            if (string.IsNullOrEmpty(item.db.name))
            {
                error += "Lỗi tại dòng : " + index + " tên liên kết chưa được nhập <br/>";
            }
            if (string.IsNullOrEmpty(item.db.link))
            {
                error += "Lỗi tại dòng : " + index + " tên liên kết chưa được nhập <br/>";
            }

            if (string.IsNullOrEmpty(item.db.code))
            {
                error += "Lỗi tại dòng : " + index + " mã liên kết chưa được nhập <br/>";
            }
            else
            {
                var check = repo._context.sys_lien_kets.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã liên kết " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
