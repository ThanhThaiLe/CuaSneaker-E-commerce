using software.common.Model;
using software.repo.erp.DataAccess;

namespace software.web.erp.Controllers
{
    partial class erp_don_hang_banController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "erp_don_hang_ban",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "erp_don_hang_ban",
            title = "erp_don_hang_ban",
            url = "/erp_don_hang_ban_index",
            type = "item",
            translate = "NAV.erp_don_hang_ban",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "erp_don_hang_ban;get_list_san_pham",
            },
            list_controller_action_public = new List<string>()
            {
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="erp_don_hang_ban;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_hang_ban;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_don_hang_ban;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_hang_ban;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_don_hang_ban;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_hang_ban;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="erp_don_hang_ban;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "erp_don_hang_ban;DataHandler",
                    }
                },
            }
        };
        private string getCode(string prefix_code)
        {
            var max = "";
            var date = DateTime.Now.ToString("yyMMdd");
            var prefix = prefix_code;
            var numIncrease = 6;
            var max_query = repo._context.erp_don_hang_bans
                .Where(q => q.code.StartsWith(prefix))
                .Where(q => q.code.Length == prefix.Length + numIncrease).Select(q => q.code);
            if (max_query.Count() > 0)
            {
                max = max_query.Max();
            }
            var code = gennerateCode(prefix, numIncrease, max);

            return code;
        }
        public string gennerateCode(string preFixCode, int Num, string max)
        {
            var result = preFixCode;
            int numGenerate = 1;
            for (int i = 0; i < Num; i++)
            {
                numGenerate = numGenerate * 10;

            }
            if (string.IsNullOrEmpty(max))
            {
                result += ((numGenerate + 1) + "").Remove(0, 1);
            }
            else
            {
                var parse = int.Parse(max.Replace(preFixCode, ""));
                result += ((numGenerate + (parse + 1)) + "").Remove(0, 1);
            }
            return result;
        }
        private bool checkModelStateCreate(erp_don_hang_ban_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(erp_don_hang_ban_model item)
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
            //    var check = repo._context.erp_don_hang_bans.Where(q => q.id != item.db.id && q.ten_khong_dau == item.db.ten_khong_dau).Count();
            //    if (check > 0)
            //    {
            //        ModelState.AddModelError("db.ten_khong_dau", "error.existed");
            //    }
            //}
            return ModelState.IsValid;
        }

    }
}
