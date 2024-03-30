using System.Collections.Generic;

namespace software.web.portal.Controllers
{
    partial class portal_homeController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "portal_home",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "portal_home",
            title = "portal_home",
            url = "/portal_home_index",
            type = "item",
            translate = "NAV.portal_home",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "portal_home;get_list_san_pham",
            },
            list_controller_action_public = new List<string>()
            {
            },
        };
    }
}
