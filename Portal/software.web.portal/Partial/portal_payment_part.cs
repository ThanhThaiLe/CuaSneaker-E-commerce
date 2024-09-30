using software.common.Model;

namespace software.web.portal.Controllers
{
    partial class portal_paymentController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "portal_payment",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "portal_payment",
            title = "portal_payment",
            url = "/portal_payment_index",
            type = "item",
            translate = "NAV.portal_payment",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
            },
            list_controller_action_public = new List<string>()
            {
              "portal_payment;getInfoReceiver",
              "portal_payment;register_don_hang",
            },
        };
    }
}
