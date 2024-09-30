using software.common.Model;
using software.repo.erp.DataAccess;

namespace software.web.erp.Controllers
{
    partial class erp_loai_thu_chiController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "erp_loai_thu_chi",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "erp_loai_thu_chi",
            title = "erp_loai_thu_chi",
            url = "/erp_loai_thu_chi_index",
            type = "item",
            translate = "NAV.erp_loai_thu_chi",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "erp_loai_thu_chi;get_list_san_pham",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="erp_loai_thu_chi;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "erp_loai_thu_chi;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_loai_thu_chi;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "erp_loai_thu_chi;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_loai_thu_chi;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "erp_loai_thu_chi;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_loai_thu_chi;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "erp_loai_thu_chi;DataHandler",
                    }
                },
            }
        };

        private bool checkModelStateCreate(erp_loai_thu_chi_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(erp_loai_thu_chi_model item)
        {
            if (String.IsNullOrEmpty(item.db.code))
            {
                ModelState.AddModelError("db.code", "error.requied");
            }
            //if (string.IsNullOrEmpty(item.db.ten_khong_dau))
            //{
            //    ModelState.AddModelError("db.ten_khong_dau", "error.requied");
            //}
            //else
            //{
            //    var check = repo._context.erp_loai_thu_chis.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
            //    if (check > 0)
            //    {
            //        ModelState.AddModelError("db.ten_khong_dau", "error.existed");
            //    }
            //}
            return ModelState.IsValid;
        }

    }
}
