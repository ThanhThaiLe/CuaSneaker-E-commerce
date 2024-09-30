using software.common.Model;
using software.repo.erp.DataAccess;

namespace software.web.erp.Controllers
{
    partial class erp_phieu_thuController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "erp_phieu_thu",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "erp_phieu_thu",
            title = "erp_phieu_thu",
            url = "/erp_phieu_thu_index",
            type = "item",
            translate = "NAV.erp_phieu_thu",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "erp_phieu_thu;getListUse",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="erp_phieu_thu;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "erp_phieu_thu;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_phieu_thu;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "erp_phieu_thu;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_phieu_thu;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "erp_phieu_thu;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_phieu_thu;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "erp_phieu_thu;DataHandler",
                    }
                },
            }
        };

        private bool checkModelStateCreate(erp_phieu_thu_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(erp_phieu_thu_model item)
        {
            if (String.IsNullOrEmpty(item.db.code))
            {
                ModelState.AddModelError("db.code", "error.requied");
            }
            //if (string.IsNullOrEmpty(item.db.ten_khong_dau))
            //{
            //    ModelState.AddModelError("db.ten_khong_dau", "error.requied");
            //}
            //else
            //{
            //    var check = repo._context.erp_phieu_thus.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
            //    if (check > 0)
            //    {
            //        ModelState.AddModelError("db.ten_khong_dau", "error.existed");
            //    }
            //}
            return ModelState.IsValid;
        }

    }
}
