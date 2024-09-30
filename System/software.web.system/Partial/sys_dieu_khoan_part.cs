using software.common.Model;
using software.repo.DataAccess;
namespace software.web.Controllers
{
    partial class sys_dieu_khoanController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_dieu_khoan",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_dieu_khoan",
            title = "sys_dieu_khoan",
            url = "/sys_dieu_khoan_index",
            type = "item",
            translate = "NAV.sys_dieu_khoan",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_dieu_khoan;getListUse",
                        "sys_dieu_khoan;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_dieu_khoan;exportToExcel",
                        "sys_dieu_khoan;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_dieu_khoan;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_dieu_khoan;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_dieu_khoan;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_dieu_khoan;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_dieu_khoan;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_dieu_khoan;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_dieu_khoan;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_dieu_khoan;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_dieu_khoan_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_dieu_khoan_model item)
        {
            if (String.IsNullOrEmpty(item.db.name))
            {
                ModelState.AddModelError("db.name", "error.requied");
            }
            else
            {
                if (item.db.name.Length > 128)
                {
                    ModelState.AddModelError("db.name", "error.khong_duoc_qua_128_ky_tu");
                }
            }
            if (String.IsNullOrEmpty(item.db.link))
            {
                ModelState.AddModelError("db.link", "error.requied");
            }
            else
            {
                if (item.db.link.Length > 500)
                {
                    ModelState.AddModelError("db.link", "error.khong_duoc_qua_500_ky_tu");
                }
            }
            if (string.IsNullOrEmpty(item.db.code))
            {
                ModelState.AddModelError("db.code", "error.requied");
            }
            else
            {
                if (item.db.code.Length > 10)
                {
                    ModelState.AddModelError("db.code", "error.khong_duoc_qua_10_ky_tu");
                }
                else
                {
                    var check = repo._context.sys_dieu_khoans.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                    if (check > 0)
                    {
                        ModelState.AddModelError("db.code", "error.existed");
                    }
                }
            }
            if (item.db.note.Length > 500)
            {
                ModelState.AddModelError("db.note", "error.khong_duoc_qua_500_ky_tu");
            }
            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_dieu_khoan_model item, int index, string error)
        {
            if (string.IsNullOrEmpty(item.db.name))
            {
                error += "Lỗi tại dòng : " + index + " tên điều khoản chưa được nhập <br/>";
            }

            if (string.IsNullOrEmpty(item.db.link))
            {
                error += "Lỗi tại dòng : " + index + " link điều khoản chưa được nhập <br/>";
            }

            if (string.IsNullOrEmpty(item.db.code))
            {
                error += "Lỗi tại dòng : " + index + " mã điều khoản chưa được nhập <br/>";
            }
            else
            {
                var check = repo._context.sys_dieu_khoans.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã điều khoản " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
