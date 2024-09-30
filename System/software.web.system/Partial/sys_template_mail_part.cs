using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_template_mailController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_template_mail",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_template_mail",
            title = "sys_template_mail",
            url = "/sys_template_mail_index",
            type = "item",
            translate = "NAV.sys_template_mail",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_template_mail;getListUse",
                        "sys_template_mail;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_template_mail;exportToExcel",
                        "sys_template_mail;ImportFormExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_template_mail;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_template_mail;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_template_mail;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_template_mail;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_template_mail;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_template_mail;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_template_mail;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_template_mail;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_template_mail_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_template_mail_model item)
        {
            if (String.IsNullOrEmpty(item.db.name))
            {
                ModelState.AddModelError("db.ten", "error.requied");
            }

            if (String.IsNullOrEmpty(item.db.template))
            {
                ModelState.AddModelError("db.template", "error.requied");
            }
            if (item.db.id_type == null)
            {
                ModelState.AddModelError("db.id_type", "error.requied");
            }
            else
            {
                var check = repo._context.sys_template_mails.Where(q => q.id != item.db.id && q.id_type == item.db.id_type).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.ten_khong_dau", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
    }
}
