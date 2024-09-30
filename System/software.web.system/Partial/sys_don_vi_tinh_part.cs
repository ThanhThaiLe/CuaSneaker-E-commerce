using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_don_vi_tinhController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_don_vi_tinh",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_don_vi_tinh",
            title = "sys_don_vi_tinh",
            url = "/sys_don_vi_tinh_index",
            type = "item",
            translate = "NAV.sys_don_vi_tinh",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_don_vi_tinh;getListUse",
                        "sys_don_vi_tinh;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_don_vi_tinh;exportToExcel",
                        "sys_don_vi_tinh;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_don_vi_tinh;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_don_vi_tinh;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_don_vi_tinh;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_don_vi_tinh;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_don_vi_tinh;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_don_vi_tinh;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_don_vi_tinh;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_don_vi_tinh;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_don_vi_tinh_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_don_vi_tinh_model item)
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
                    var check = repo._context.sys_don_vi_tinhs.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
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
        private string CheckErrorImport(sys_don_vi_tinh_model item, int index, string error)
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
                var check = repo._context.sys_don_vi_tinhs.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã đơn vị tính " + item.db.code + " đã tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
