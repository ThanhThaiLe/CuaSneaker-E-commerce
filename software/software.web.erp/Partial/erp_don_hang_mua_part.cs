using software.repo.erp.DataAccess;
using System.Collections.Generic;

namespace software.web.erp.Controllers
{
    partial class erp_don_hang_muaController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "erp_don_hang_mua",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "erp_don_hang_mua",
            title = "erp_don_hang_mua",
            url = "/erp_don_hang_mua_index",
            type = "item",
            translate = "NAV.erp_don_hang_mua",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "erp_don_hang_mua;get_list_san_pham",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="erp_don_hang_mua;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_hang_mua;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_don_hang_mua;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_hang_mua;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_don_hang_mua;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_hang_mua;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_don_hang_mua;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_hang_mua;DataHandler",
                    }
                },
            }
        };

        private bool checkModelStateCreate(erp_don_hang_mua_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(erp_don_hang_mua_model item)
        {
            //if (String.IsNullOrEmpty(item.db.id_phieu_nhap))
            //{
            //    ModelState.AddModelError("db.id_phieu_nhap", "error.requied");
            //}
            //if (string.IsNullOrEmpty(item.db.ten_khong_dau))
            //{
            //    ModelState.AddModelError("db.ten_khong_dau", "error.requied");
            //}
            //else
            //{
            //    var check = repo._context.erp_don_hang_muas.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
            //    if (check > 0)
            //    {
            //        ModelState.AddModelError("db.ten_khong_dau", "error.existed");
            //    }
            //}
            return ModelState.IsValid;
        }

    }
}
