using software.common.Model;
using software.repo.erp.DataAccess;

namespace software.web.erp.Controllers
{
    partial class erp_nhap_khoController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "erp_nhap_kho",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "erp_nhap_kho",
            title = "erp_nhap_kho",
            url = "/erp_nhap_kho_index",
            type = "item",
            translate = "NAV.erp_nhap_kho",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "erp_nhap_kho;get_list_san_pham",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="erp_nhap_kho;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "erp_nhap_kho;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_nhap_kho;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "erp_nhap_kho;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_nhap_kho;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "erp_nhap_kho;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_nhap_kho;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "erp_nhap_kho;DataHandler",
                    }
                },
            }
        };

        private bool checkModelStateCreate(erp_nhap_kho_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(erp_nhap_kho_model item)
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
            //    var check = repo._context.erp_nhap_khos.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
            //    if (check > 0)
            //    {
            //        ModelState.AddModelError("db.ten_khong_dau", "error.existed");
            //    }
            //}
            return ModelState.IsValid;
        }

    }
}
