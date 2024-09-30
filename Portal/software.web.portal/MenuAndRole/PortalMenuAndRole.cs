using software.common.Model;
using software.web.Controllers;
using software.web.portal.Controllers;

namespace software.web.portal.MenuAndRole
{
    public static class PortalMenuAndRole
    {
        public static List<ControllerAppModel> list = new List<ControllerAppModel>()
        {
            portal_paymentController.declare,
            portal_homeController.declare,
            portal_san_phamController.declare,
            portal_userController.declare,
        };
    }
}
