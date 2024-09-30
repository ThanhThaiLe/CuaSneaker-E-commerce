using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_loai_san_phamController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_loai_san_pham",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_loai_san_pham",
            title = "sys_loai_san_pham",
            url = "/sys_loai_san_pham_index",
            type = "item",
            translate = "NAV.sys_loai_san_pham",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_loai_san_pham;getListUse",
                        "sys_loai_san_pham;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_loai_san_pham;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_loai_san_pham;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_loai_san_pham;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_loai_san_pham;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_loai_san_pham;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_loai_san_pham;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_loai_san_pham;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_loai_san_pham;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_loai_san_pham;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_loai_san_pham_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_loai_san_pham_model item)
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
                var check = repo._context.sys_loai_san_phams.Where(q => q.id != item.db.id && q.code == item.db.code.Trim()).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.code", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_loai_san_pham_model item, int index, string error)
        {
            if (string.IsNullOrEmpty(item.db.name))
            {
                error += "Lỗi tại dòng : " + index + " loại sản phẩm chưa được nhập <br/>";
            }
            if (string.IsNullOrEmpty(item.db.code))
            {
                error += "Lỗi tại dòng : " + index + " mã loại sản phẩm chưa được nhập <br/>";
            }
            else
            {
                var check = repo._context.sys_loai_san_phams.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã loại sản phẩm " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
