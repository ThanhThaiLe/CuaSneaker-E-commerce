using software.web.portal.Controllers;
using System.Collections.Generic;

namespace software.web.kho.MenuAndRole
{
    public static class KhoMenuAndRole
    {
        public static List<ControllerAppModel> list = new List<ControllerAppModel>()
        {
            portal_homeController.declare,
            portal_san_phamController.declare,
        };
    }
}
