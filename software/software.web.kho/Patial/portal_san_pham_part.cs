using System.Collections.Generic;

namespace software.web.portal.Controllers
{
    partial class portal_san_phamController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "portal_san_pham",
            icon = "badge",
            icon_image = "",
            module = "system",
            id = "portal_san_pham_repo",
            title = "portal_san_pham_repo",
            url = "/portal_san_pham_repo_index",
            type = "item",
            translate = "NAV.portal_san_pham_repo",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "portal_san_pham_repo;get_list_san_pham",
            },
            list_controller_action_public = new List<string>()
            {
            },
        };
    }
}
