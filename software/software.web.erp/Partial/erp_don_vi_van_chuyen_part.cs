using software.repo.erp.DataAccess;
using System;
using System.Collections.Generic;

namespace software.web.erp.Controllers
{
    partial class erp_don_vi_van_chuyenController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "erp_don_vi_van_chuyen",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "erp_don_vi_van_chuyen",
            title = "erp_don_vi_van_chuyen",
            url = "/erp_don_vi_van_chuyen_index",
            type = "item",
            translate = "NAV.erp_don_vi_van_chuyen",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "erp_don_vi_van_chuyen;getListUse",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="erp_don_vi_van_chuyen;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_vi_van_chuyen;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_don_vi_van_chuyen;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_vi_van_chuyen;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_don_vi_van_chuyen;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_vi_van_chuyen;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_don_vi_van_chuyen;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_vi_van_chuyen;DataHandler",
                    }
                },
            }
        };

        private bool checkModelStateCreate(erp_don_vi_van_chuyen_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(erp_don_vi_van_chuyen_model item)
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
            //    var check = repo._context.erp_don_vi_van_chuyens.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
            //    if (check > 0)
            //    {
            //        ModelState.AddModelError("db.ten_khong_dau", "error.existed");
            //    }
            //}
            return ModelState.IsValid;
        }

    }
}
