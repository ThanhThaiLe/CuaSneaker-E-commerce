using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_quan_huyenController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_quan_huyen",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_quan_huyen",
            title = "sys_quan_huyen",
            url = "/sys_quan_huyen_index",
            type = "item",
            translate = "NAV.sys_quan_huyen",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_quan_huyen;getListUse",
                        "sys_quan_huyen;getListUseWithIdTinhThanh",
                        "sys_quan_huyen;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_quan_huyen;exportToExcel",
                        "sys_quan_huyen;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_quan_huyen;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_quan_huyen;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_quan_huyen;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_quan_huyen;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_quan_huyen;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_quan_huyen;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_quan_huyen;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_quan_huyen;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_quan_huyen_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_quan_huyen_model item)
        {
            if (String.IsNullOrEmpty(item.db.ten))
            {
                ModelState.AddModelError("db.ten", "error.requied");
            }
            if (string.IsNullOrEmpty(item.db.ten_khong_dau))
            {
                ModelState.AddModelError("db.ten_khong_dau", "error.requied");
            }
            else
            {
                var check = repo._context.sys_quan_huyens.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.ten_khong_dau", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
    }
}
