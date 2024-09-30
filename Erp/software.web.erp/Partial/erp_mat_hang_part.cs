using software.common.Model;
using software.repo.erp.DataAccess;
namespace software.web.erp.Controllers
{
    partial class erp_mat_hangController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "erp_mat_hang",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "erp_mat_hang",
            title = "erp_mat_hang",
            url = "/erp_mat_hang_index",
            type = "item",
            translate = "NAV.erp_mat_hang",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "erp_mat_hang;get_list_san_pham",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="erp_mat_hang;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "erp_mat_hang;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_mat_hang;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "erp_mat_hang;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_mat_hang;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "erp_mat_hang;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_mat_hang;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "erp_mat_hang;DataHandler",
                    }
                },
            }
        };

        private bool checkModelStateCreate(erp_mat_hang_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(erp_mat_hang_model item)
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
            //    var check = repo._context.erp_mat_hangs.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
            //    if (check > 0)
            //    {
            //        ModelState.AddModelError("db.ten_khong_dau", "error.existed");
            //    }
            //}
            return ModelState.IsValid;
        }

    }
}
