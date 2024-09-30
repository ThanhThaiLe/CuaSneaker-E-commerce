using software.common.Model;
using software.repo.DataAccess;

namespace software.web.Controllers
{
    partial class sys_san_phamController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_san_pham",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_san_pham",
            title = "sys_san_pham",
            url = "/sys_san_pham_index",
            type = "item",
            translate = "NAV.sys_san_pham",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_san_pham;fakeData",
                        "sys_san_pham;getListUse",
                        "sys_san_pham;get_code_san_pham",
                        "sys_san_pham;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_san_pham;getElementById",
                        "sys_san_pham;ImportFormExcel",
                        "sys_san_pham;exportToExcel",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_san_pham;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_san_pham;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_san_pham;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_san_pham;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_san_pham;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_san_pham;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_san_pham;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_san_pham;DataHandler",
                    }
                },
            }
        };
        private string getCode()
        {
            var max = "";
            var date = DateTime.Now.ToString("yyMMdd");
            var prefix = "SP";
            var numIncrease = 6;
            var max_query = repo._context.sys_san_phams
                .Where(q => q.ma_san_pham.StartsWith(prefix))
                .Where(q => q.ma_san_pham.Length == prefix.Length + numIncrease).Select(q => q.ma_san_pham);
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
        private bool checkModelStateCreate(sys_san_pham_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_san_pham_model item)
        {
            if (String.IsNullOrEmpty(item.db.ten_san_pham))
            {
                ModelState.AddModelError("db.ten_san_pham", "error.requied");
            }
            else
            {
                var check = repo._context.sys_san_phams.Where(q => q.id != item.db.id && q.ten_san_pham == item.db.ten_san_pham).Count();
                if (check > 0)
                {
                    ModelState.AddModelError("db.ten_san_pham", "error.requied");
                }
            }
            if (String.IsNullOrEmpty(item.db.ma_san_pham))
            {
                ModelState.AddModelError("db.ma_san_pham", "error.requied");
            }
            else
            {
                var check = repo._context.sys_san_phams.Where(q => q.ma_san_pham == item.db.ma_san_pham && q.status_del == 1).SingleOrDefault();
                if (check != null)
                {
                    ModelState.AddModelError("db.hinh_anh", "error.existed");
                }
            }
            if (String.IsNullOrEmpty(item.db.hinh_anh))
            {
                ModelState.AddModelError("db.hinh_anh", "error.requied");
            }
            if (item.db.id_loai_san_pham == null)
            {
                ModelState.AddModelError("db.id_loai_san_pham", "error.requied");
            }
            if (item.db.id_don_vi_tinh == null)
            {
                ModelState.AddModelError("db.id_don_vi_tinh", "error.requied");
            }
            if (item.db.id_nhan_hieu == null)
            {
                ModelState.AddModelError("db.id_nhan_hieu", "error.requied");
            }

            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_san_pham_model item, int index, string error)
        {
            if (string.IsNullOrEmpty(item.db.ten_san_pham))
            {
                error += "Lỗi tại dòng : " + index + " tên sản phẩm chưa được nhập <br/>";
            }
            else
            {
                var check = repo._context.sys_san_phams.Where(q => q.id != item.db.id && q.ten_san_pham == item.db.ten_san_pham).Count();
                if (check > 0)
                {
                    error += "Lỗi tại dòng : " + index + " sản phẩm " + item.db.ten_san_pham + " đã tồn tại <br/>";
                }
            }
            if (string.IsNullOrEmpty(item.ten_loai_san_pham))
            {
                error += "Lỗi tại dòng : " + index + " mã loại sản phẩm chưa được nhập <br/>";
            }
            else
            {
                if (item.db.id_loai_san_pham == 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã loại sản phẩm " + item.ten_loai_san_pham + " không tồn tại <br/>";
                }
            }
            if (string.IsNullOrEmpty(item.ten_nhan_hieu))
            {
                error += "Lỗi tại dòng : " + index + " mã nhãn hiệu chưa được nhập <br/>";
            }
            else
            {
                if (item.db.id_nhan_hieu == 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã nhãn hiệu " + item.ten_nhan_hieu + " không tồn tại <br/>";
                }
            }
            if (string.IsNullOrEmpty(item.ten_don_vi_tinh))
            {
                error += "Lỗi tại dòng : " + index + " mã đơn vị tính chưa được nhập <br/>";
            }
            else
            {
                if (item.db.id_don_vi_tinh == 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã đơn vị tính " + item.ten_don_vi_tinh + " không tồn tại <br/>";
                }
            }

            return error;
        }
    }
}
