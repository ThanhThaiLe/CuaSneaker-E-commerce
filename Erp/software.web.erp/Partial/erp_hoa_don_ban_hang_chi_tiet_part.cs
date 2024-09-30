﻿using software.common.Model;
using software.repo.erp.DataAccess;
namespace software.web.erp.Controllers
{
    partial class erp_hoa_don_ban_hang_chi_tietController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "erp_hoa_don_ban_hang_chi_tiet",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "erp_hoa_don_ban_hang_chi_tiet",
            title = "erp_hoa_don_ban_hang_chi_tiet",
            url = "/erp_hoa_don_ban_hang_chi_tiet_index",
            type = "item",
            translate = "NAV.erp_hoa_don_ban_hang_chi_tiet",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "erp_hoa_don_ban_hang_chi_tiet;get_list_san_pham",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="erp_hoa_don_ban_hang_chi_tiet;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "erp_hoa_don_ban_hang_chi_tiet;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_hoa_don_ban_hang_chi_tiet;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "erp_hoa_don_ban_hang_chi_tiet;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_hoa_don_ban_hang_chi_tiet;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "erp_hoa_don_ban_hang_chi_tiet;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_hoa_don_ban_hang_chi_tiet;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "erp_hoa_don_ban_hang_chi_tiet;DataHandler",
                    }
                },
            }
        };

        private bool checkModelStateCreate(erp_hoa_don_ban_hang_chi_tiet_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(erp_hoa_don_ban_hang_chi_tiet_model item)
        {
            if (String.IsNullOrEmpty(item.db.id_don_hang_ban))
            {
                ModelState.AddModelError("db.code", "error.requied");
            }
            //if (string.IsNullOrEmpty(item.db.ten_khong_dau))
            //{
            //    ModelState.AddModelError("db.ten_khong_dau", "error.requied");
            //}
            //else
            //{
            //    var check = repo._context.erp_hoa_don_ban_hang_chi_tiets.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
            //    if (check > 0)
            //    {
            //        ModelState.AddModelError("db.ten_khong_dau", "error.existed");
            //    }
            //}
            return ModelState.IsValid;
        }

    }
}
