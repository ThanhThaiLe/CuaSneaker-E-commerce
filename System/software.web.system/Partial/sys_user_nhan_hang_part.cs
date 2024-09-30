using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_user_nhan_hangController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_user_nhan_hang",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_user_nhan_hang",
            title = "sys_user_nhan_hang",
            url = "/sys_user_nhan_hang_index",
            type = "item",
            translate = "NAV.sys_user_nhan_hang",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_user_nhan_hang;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_user_nhan_hang;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_user_nhan_hang;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_user_nhan_hang;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_user_nhan_hang;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_user_nhan_hang;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_user_nhan_hang;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_user_nhan_hang;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_user_nhan_hang_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateEdit(sys_user_nhan_hang_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_user_nhan_hang_model item)
        {
            if (String.IsNullOrEmpty(item.db.id))
            {
                ModelState.AddModelError("db.fullname", "error.requied");
            }
            return ModelState.IsValid;
        }
    }
}
