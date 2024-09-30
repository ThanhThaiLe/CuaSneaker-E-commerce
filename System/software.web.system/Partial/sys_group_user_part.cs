using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_group_userController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_group_user",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_group_user",
            title = "sys_group_user",
            url = "/sys_group_user_index",
            type = "item",
            translate = "NAV.sys_group_user",
            is_show_all_user = true,
            list_public_Non_action_controller = new List<string>()
            {
                        "sys_group_user;create",
                        "sys_group_user;getListUse",
                        "sys_group_user;DataHandler",
                        "sys_group_user;getListItem",
                        "sys_group_user;getListRole",
                        "sys_group_user;getListRoleFull",
                        "sys_group_user;edit",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_group_user;create",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_group_user;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_group_user;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_group_user;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_group_user;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_group_user;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_group_user;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_group_user;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_group_user;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_group_user_model item)
        {
            return checkModelStateCreateEdit(ActionEnumForm.create, item);
        }
        private bool checkModelStateCreateEdit(ActionEnumForm action, sys_group_user_model item)
        {
            if (String.IsNullOrEmpty(item.db.name))
            {
                ModelState.AddModelError("db.name", "error.requied");
            }
            var search = repo.FindAll().Where(q => q.db.name == item.db.name && q.db.id != item.db.id).Count();
            if (search > 0)
            {

                ModelState.AddModelError("db.name", "error.existed");
            }
            if (item.list_item.Count() == 0 && action == ActionEnumForm.create)
            {

                ModelState.AddModelError("db.list_item", "error.requied");
            }
            return ModelState.IsValid;
        }
    }
}
