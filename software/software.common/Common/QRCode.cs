using QRCoder;
using software.common.Model;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Web;

namespace software.common.Common
{
    public class QRCode
    {
        public AppSetting _appsetting;
        public QRCode(AppSetting appsetting)
        {
            _appsetting = appsetting;
        }
        public byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public string save_qr_code(byte[] bit_map, string id)
        {
            using (MemoryStream ms = new MemoryStream())
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
                var file_path = "/FileManager/Dowload/?filename=" + HttpUtility.UrlDecode(pathsave.Replace(Path.Combine(currentpath, "file_upload"), ""));
                // lưu vào db
                //...

                return file_path;
            }
        }
        public void generate_qr_code(dynamic model)
        {
            try
            {
                var currentpath = _appsetting.folder_path;
                var path_logo = Path.Combine(currentpath, "wwwroot", "assets", "image", "logos");
                if (!Directory.Exists(path_logo))
                    Directory.CreateDirectory(path_logo);
                var file_logo = Path.Combine(path_logo, "logo.png");

                QRCodeGenerator qr_code_generator = new QRCodeGenerator();
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

    }
}
