using software.repo.DataAccess;
using System;
using System.Collections.Generic;

namespace software.web.Controllers
{
    partial class sys_thong_tin_websiteController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_thong_tin_website",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_thong_tin_website",
            title = "sys_thong_tin_website",
            url = "/sys_thong_tin_website_index",
            type = "item",
            translate = "NAV.sys_thong_tin_website",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_thong_tin_website;getListUse",
                        "sys_thong_tin_website;getThongTinWebsite",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_thong_tin_website;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_thong_tin_website;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_thong_tin_website;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_thong_tin_website;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_thong_tin_website;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_thong_tin_website;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_thong_tin_website;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_thong_tin_website;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(sys_thong_tin_website_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_thong_tin_website_model item)
        {
            if (String.IsNullOrEmpty(item.db.image_logo))
            {
                ModelState.AddModelError("db.image_logo", "error.requied");
            }
            if (String.IsNullOrEmpty(item.db.image_footer))
            {
                ModelState.AddModelError("db.image_footer", "error.requied");
            }
            if (String.IsNullOrEmpty(item.db.dia_chi))
            {
                ModelState.AddModelError("db.dia_chi", "error.requied");
            }
            if (String.IsNullOrEmpty(item.db.so_dien_thoai))
            {
                ModelState.AddModelError("db.so_dien_thoai", "error.requied");
            }
            if (String.IsNullOrEmpty(item.db.email))
            {
                ModelState.AddModelError("db.email", "error.requied");
            }
            if (!String.IsNullOrEmpty(item.db.link_facebook) && String.IsNullOrEmpty(item.db.image_facebook))
            {
                ModelState.AddModelError("db.image_facebook", "error.requied");
            }
            if (!String.IsNullOrEmpty(item.db.link_youtube) && String.IsNullOrEmpty(item.db.image_youtube))
            {
                ModelState.AddModelError("db.image_youtube", "error.requied");
            }
            if (!String.IsNullOrEmpty(item.db.link_linkedin) && String.IsNullOrEmpty(item.db.image_linkedin))
            {
                ModelState.AddModelError("db.image_linkedin", "error.requied");
            }
            if (!String.IsNullOrEmpty(item.db.link_instagram) && String.IsNullOrEmpty(item.db.image_instagram))
            {
                ModelState.AddModelError("db.image_instagram", "error.requied");
            }


            return ModelState.IsValid;
        }
    }
}
