using System.Collections.Generic;

namespace software.web.portal.Controllers
{
    partial class portal_san_phamController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "portal_san_pham",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "portal_san_pham",
            title = "portal_san_pham",
            url = "/portal_san_pham_index",
            type = "item",
            translate = "NAV.portal_san_pham",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "portal_san_pham;get_list_san_pham_page",
                        "portal_san_pham;get_list_san_pham",
                        "portal_san_pham;get_detail_san_pham",
            },
            list_controller_action_public = new List<string>()
            {
            },
        };
    }
}
