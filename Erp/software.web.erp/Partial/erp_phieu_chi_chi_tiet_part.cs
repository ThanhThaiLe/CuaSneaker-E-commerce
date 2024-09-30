using software.common.Model;
using software.repo.erp.DataAccess;
namespace software.web.erp.Controllers
{
    partial class erp_phieu_chi_chi_tietController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "erp_phieu_chi_chi_tiet",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "erp_phieu_chi_chi_tiet",
            title = "erp_phieu_chi_chi_tiet",
            url = "/erp_phieu_chi_chi_tiet_index",
            type = "item",
            translate = "NAV.erp_phieu_chi_chi_tiet",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "erp_phieu_chi_chi_tiet;getListUse",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="erp_phieu_chi_chi_tiet;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "erp_phieu_chi_chi_tiet;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_phieu_chi_chi_tiet;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "erp_phieu_chi_chi_tiet;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_phieu_chi_chi_tiet;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "erp_phieu_chi_chi_tiet;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_phieu_chi_chi_tiet;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "erp_phieu_chi_chi_tiet;DataHandler",
                    }
                },
            }
        };

        private bool checkModelStateCreate(erp_phieu_chi_chi_tiet_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(erp_phieu_chi_chi_tiet_model item)
        {
            if (String.IsNullOrEmpty(item.db.note))
            {
                ModelState.AddModelError("db.code", "error.requied");
            }
            //if (string.IsNullOrEmpty(item.db.ten_khong_dau))
            //{
            //    ModelState.AddModelError("db.ten_khong_dau", "error.requied");
            //}
            //else
            //{
            //    var check = repo._context.erp_phieu_chi_chi_tiets.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
            //    if (check > 0)
            //    {
            //        ModelState.AddModelError("db.ten_khong_dau", "error.existed");
            //    }
            //}
            return ModelState.IsValid;
        }

    }
}
