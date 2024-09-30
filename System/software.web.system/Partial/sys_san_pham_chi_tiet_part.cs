using QRCoder;
using software.common.Model;
using software.repo.DataAccess;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace software.web.Controllers
{
    partial class sys_san_pham_chi_tietController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "sys_san_pham_chi_tiet",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "sys_san_pham_chi_tiet",
            title = "sys_san_pham_chi_tiet",
            url = "/sys_san_pham_chi_tiet_index",
            type = "item",
            translate = "NAV.sys_san_pham_chi_tiet",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "sys_san_pham_chi_tiet;getListUse",
                        "sys_san_pham_chi_tiet;get_code_san_pham",
                        "sys_san_pham_chi_tiet;downloadTemp",
            },
            list_controller_action_public = new List<string>()
            {
                        "sys_san_pham_chi_tiet;ImportFormExcel",
                        "sys_san_pham_chi_tiet;upload_file",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="sys_san_pham_chi_tiet;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "sys_san_pham_chi_tiet;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_san_pham_chi_tiet;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "sys_san_pham_chi_tiet;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_san_pham_chi_tiet;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "sys_san_pham_chi_tiet;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="sys_san_pham_chi_tiet;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "sys_san_pham_chi_tiet;DataHandler",
                    }
                },
            }
        };

        public string save_qr_code(byte[] bit_map, string id)
        {
            using (MemoryStream ms = new MemoryStream(bit_map))
            {
                var img = Image.FromStream(ms);
                var currentpath = _appsetting.folder_path;
                var path = Path.Combine(currentpath, "file_upload", "qr_code", id);
                Thread.Sleep(1);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo item in directoryInfo.GetFiles())
                {
                    item.Delete();
                }
                var pathsave = Path.Combine(path, "qr.png");
                img.Save(pathsave, ImageFormat.Png);
                var file_path = "/FileManager/Download/?filename=" + HttpUtility.UrlDecode(pathsave.Replace(Path.Combine(currentpath, "file_upload"), ""));
                var db = repo._context.sys_san_pham_chi_tiets.Where(q => q.id == long.Parse(id)).SingleOrDefault();
                db.qr_image = file_path;
                repo._context.SaveChanges();
                return file_path;
            }
        }
        public void generate_qr_code(dynamic model)
        {
            try
            {
                var currentpath = _appsetting.folder_path;
                var path_logo = Path.Combine(currentpath, "wwwroot", "assets", "images", "logos");
                if (!Directory.Exists(path_logo))
                    Directory.CreateDirectory(path_logo);
                var file_logo = Path.Combine(path_logo, "logo.jpg");

                QRCodeGenerator qr_code_generator = new QRCodeGenerator();
                // gắn đường link dẫn tới trang detail sản phẩm
                string link = _appsetting.domain + "software";
                QRCodeData qr_code_info = qr_code_generator.CreateQrCode(link, QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qr_code = new QRCoder.QRCode(qr_code_info);

                Bitmap qr_bit_map = qr_code.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile(file_logo));
                byte[] bit_map_array = BitmapToByteArray(qr_bit_map);
                string qr_uri = string.Format("data:image/png;base,{0}", Convert.ToBase64String(bit_map_array));
                string qr = save_qr_code(bit_map_array, model.db.id);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
        public byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private bool checkModelStateCreate(sys_san_pham_chi_tiet_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(sys_san_pham_chi_tiet_model item)
        {

            if (item.db.gia_ban == null)
            {
                ModelState.AddModelError("db.gia_ban", "error.requied");
            }
            if (item.list_id_size.Count() == 0)
            {
                ModelState.AddModelError("db.id_size", "error.requied");
            }
            if (item.db.id_color == null)
            {
                ModelState.AddModelError("db.id_color", "error.requied");
            }

            if (string.IsNullOrEmpty(item.db.mo_ta))
            {
                ModelState.AddModelError("db.mo_ta", "error.requied");
            }
            if (string.IsNullOrEmpty(item.db.id_san_pham))
            {
                ModelState.AddModelError("db.id_san_pham", "error.requied");
            }
            else
            {
                var check = repo._context.sys_san_pham_chi_tiets.Where(q => q.id != item.db.id && q.id_san_pham == item.db.id_san_pham && q.id_color == item.db.id_color && q.status_del == 1).SingleOrDefault();
                if (check != null)
                {
                    ModelState.AddModelError("db.id_san_pham", "error.existed");
                }
            }
            return ModelState.IsValid;
        }
        private string CheckErrorImport(sys_san_pham_chi_tiet_model item, int index, string error)
        {
            if (item.db.gia_ban == null)
            {
                error += "Lỗi tại dòng : " + index + " giá bán không được để trống <br/>";
            }
            if (string.IsNullOrEmpty(item.size))
            {
                error += "Lỗi tại dòng : " + index + " chưa nhập tỉ lệ size <br/>";
            }
            else
            {
                // check code size existed
                foreach (var code in item.list_code_size)
                {
                    var size = repo._context.sys_sizes.Where(q => q.code.Trim().ToLower() == code).Where(q => q.status_del == 1).SingleOrDefault();
                    if (size == null)
                    {
                        error += "Lỗi tại dòng : " + index + " mã size " + code + " không tồn tại trong hệ thống <br/>";
                    }
                }
            }
            if (string.IsNullOrEmpty(item.color_code))
            {
                error += "Lỗi tại dòng : " + index + " chưa nhập mã màu <br/>";
            }
            else
            {
                if (item.db.id_color == 0)
                {
                    error += "Lỗi tại dòng : " + index + " mã màu " + item.color_code + " không tồn tại <br/>";
                }
            }
            if (string.IsNullOrEmpty(item.ma_san_pham))
            {
                error += "Lỗi tại dòng : " + index + " chưa nhập mã sản phẩm <br/>";
            }
            else
            {
                if (string.IsNullOrEmpty(item.db.id_san_pham))
                {
                    error += "Lỗi tại dòng : " + index + " mã sản phẩm " + item.ma_san_pham + " không tồn tại <br/>";
                }
                else
                {
                    var check = repo._context.sys_san_pham_chi_tiets.Where(q => q.id != item.db.id && q.id_san_pham == item.db.id_san_pham && q.id_color == item.db.id_color && q.status_del == 1).SingleOrDefault();
                    if (check != null)
                    {
                        error += "Lỗi tại dòng : " + index + " mã sản phẩm " + item.ma_san_pham + ", mã màu " + item.color_code + ", tỉ lệ size " + item.size + " đã tồn tại <br/>";
                    }
                }
            }
            return error;
        }
    }
}
