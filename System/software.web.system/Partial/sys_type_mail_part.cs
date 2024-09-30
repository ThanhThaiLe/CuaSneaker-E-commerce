using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_type_mailController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_type_mail",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_type_mail",
            title = "sys_type_mail",
            url = "/sys_type_mail_index",
            type = "item",
            translate = "NAV.sys_type_mail",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_type_mail;getListUse",
                        "sys_type_mail;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_type_mail;exportToExcel",
                        "sys_type_mail;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_type_mail;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_type_mail;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_type_mail;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_type_mail;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_type_mail;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_type_mail;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_type_mail;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_type_mail;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_type_mail_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_type_mail_model item)
        {
            if (String.IsNullOrEmpty(item.db.name))
            {
                ModelState.AddModelError("db.ten", "error.requied");
            }
            if (string.IsNullOrEmpty(item.db.code))
            {
                ModelState.AddModelError("db.ten_khong_dau", "error.requied");
            }
            else
            {
                var check = repo._context.sys_type_mails.Where(q => q.id != item.db.id && q.code == item.db.code).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.ten_khong_dau", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
    }
}
