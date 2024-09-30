using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_khach_hangController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_khach_hang",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_khach_hang",
            title = "sys_khach_hang",
            url = "/sys_khach_hang_index",
            type = "item",
            translate = "NAV.sys_khach_hang",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_khach_hang;getUserLogin",
                        "sys_khach_hang;create",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_khach_hang;initeData",
                        "sys_khach_hang;getContacts",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_khach_hang;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_khach_hang;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_khach_hang;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_khach_hang;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_khach_hang;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_khach_hang;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_khach_hang;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_khach_hang;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_khach_hang_model item)
        {
            return checkModelStateCreate(item);
        }
        private bool checkModelStateCreateEdit(sys_khach_hang_model item)
        {
            //if (String.IsNullOrEmpty(item.db.id))
            //{
            //    ModelState.AddModelError("db.fullname", "Không được để rỗng");
            //}
            return ModelState.IsValid;
        }
    }
}
