using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using software.common.Common;
using software.common.ControllerBase;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.repo.DataAccess;
using software.repo.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace software.web.Controllers
{
    public partial class sys_san_phamController : BaseAuthenticationController
    {
        private sys_san_pham_repo repo;
        private AppSetting _appsetting;
        private readonly sys_san_pham_chi_tiet_repo repo_detail;
        public sys_san_phamController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo_detail = new sys_san_pham_chi_tiet_repo(context);
            repo = new sys_san_pham_repo(context);
            _appsetting = appsetting.Value;
        }

        public async Task<IActionResult> fakeData()
        {
            var list_san_pham = repo.FindAll().ToList();
            foreach (var item in list_san_pham)
            {
                sys_san_pham_model san_pham = new sys_san_pham_model();
                san_pham = item;
                san_pham.db.ma_san_pham = getCode();
                san_pham.db.id = Guid.NewGuid().ToString();
                await repo.insert(san_pham);
                foreach (var item1 in item.list_detail)
                {
                    sys_san_pham_chi_tiet_model san_pham_chi_tiet = new sys_san_pham_chi_tiet_model();
                    san_pham_chi_tiet = item1;
                    san_pham_chi_tiet.db.id_san_pham = san_pham.db.id;
                    await repo_detail.insert(san_pham_chi_tiet);
                }
            }
            return Json("");
        }

        public IActionResult get_code_san_pham()
        {
            var result = getCode();
            return Json(result);
        }
        public IActionResult getListUse()
        {
            var result = repo._context.sys_san_phams.Where(q => q.status_del == 1).Select(q => new sys_common_string_model
            {
                id = q.id,
                name = q.ten_san_pham + "(" + q.ma_san_pham + ")",
            }).ToList();
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_san_pham_model>(json.GetValue("data").ToString());
            var check = checkModelStateCreate(model);
            if (!check)
            {
                return generateError();
            }
            model.db.status_del = 1;
            model.db.create_date = DateTime.Now;
            model.db.update_date = DateTime.Now;
            model.db.create_by = getUserId();
            model.db.update_by = getUserId();
            await repo.insert(model);
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> edit([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_san_pham_model>(json.GetValue("data").ToString());
            var check = checkModelStateCreate(model);
            if (!check)
            {
                return generateError();
            }
            model.db.update_date = DateTime.Now;
            model.db.update_by = getUserId();
            await repo.update(model);
            return Json(model);
        }
        [HttpDelete]
        public async Task<IActionResult> update_status(string id)
        {
            await repo.delete(id, 2);
            return Json(id);
        }
        [HttpGet]
        public async Task<IActionResult> getElementById(string id)
        {
            var model = await repo.getElementById(id);
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> DataHandler([FromBody] JObject json)
        {
            try
            {
                var a = Request;
                var param = JsonConvert.DeserializeObject<DTParameters>(json.GetValue("param").ToString());
                var dictionary = new Dictionary<string, string>();
                dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json.GetValue("data").ToString());
                var search = dictionary["search"];
                var status_del = int.Parse(dictionary["status_del"]);
                var id_nhan_hieu = long.Parse(dictionary["id_nhan_hieu"]);
                var id_loai_san_pham = long.Parse(dictionary["id_loai_san_pham"]);
                var query = repo.FindAll()
                    .Where(q => q.db.id_loai_san_pham == id_loai_san_pham || id_loai_san_pham == -1)
                    .Where(q => q.db.id_nhan_hieu == id_nhan_hieu || id_nhan_hieu == -1)
                    .Where(q => q.db.status_del == status_del)
                    .Where(q => q.db.ten_san_pham.Contains(search) || q.db.ma_san_pham.Contains(search) || search == "");
                var count = query.Count();
                var dataList = await Task.Run(() => query.OrderByDescending(q => q.db.update_date).Skip(param.Start).Take(param.Length).ToList());
                DTResult<sys_san_pham_model> result = new DTResult<sys_san_pham_model>
                {
                    start = param.Start,
                    draw = param.Draw,
                    data = dataList,
                    recordsFiltered = count,
                    recordsTotal = count,
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> DataHandlerChooseProduct([FromBody] JObject json)
        {
            try
            {
                var a = Request;
                var param = JsonConvert.DeserializeObject<DTParameters>(json.GetValue("param").ToString());
                var dictionary = new Dictionary<string, string>();
                dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json.GetValue("data").ToString());
                var search = dictionary["search"];
                var status_del = int.Parse(dictionary["status_del"]);
                var query = repo.FindAll().Where(q => q.db.status_del == status_del);
                var count = query.Count();
                var dataList = await Task.Run(() => query.OrderByDescending(q => q.db.update_date).Skip(param.Start).Take(param.Length).ToList());
                DTResult<sys_san_pham_model> result = new DTResult<sys_san_pham_model>
                {
                    start = param.Start,
                    draw = param.Draw,
                    data = dataList,
                    recordsFiltered = count,
                    recordsTotal = count,
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }

        }

        [AllowAnonymous]
        public ActionResult downloadTemp()
        {
            var curentpath = Directory.GetCurrentDirectory();
            string newpath = Path.Combine(curentpath, "wwwroot", "assets", "templates");
            if (!Directory.Exists(newpath))
                Directory.CreateDirectory(newpath);

            string file = newpath + "\\sys_san_pham.xlsx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(file);
            System.IO.File.WriteAllBytes(file, fileBytes);
            MemoryStream ms = new MemoryStream(fileBytes);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "sys_san_pham.xlsx");
        }
        [HttpPost]
        public async Task<IActionResult> ImportFormExcel()
        {
            var error = "";
            IFormFile file = Request.Form.Files[0];
            var nameSheet = "SanPham";
            if (file.Length > 0)
            {
                var count_error = 0;
                try
                {
                    var list_row = handleImportExcelName(file, nameSheet);
                    var list_model = new List<sys_san_pham_model>();
                    for (int i = 0; i < list_row.Count(); i++)
                    {
                        var itemForm = list_row[i].list_cell.ToList();
                        var model = new sys_san_pham_model();
                        var stt = itemForm[0].value.ToString().Trim() ?? "";
                        var name = itemForm[1].value.ToString().Trim() ?? "";
                        model.db.ten_san_pham = name;
                        var nhan_hieu = itemForm[2].value.ToString().Trim() ?? "";
                        model.ten_nhan_hieu = nhan_hieu;
                        model.db.id_nhan_hieu = repo._context.sys_nhan_hieus.Where(q => q.code.Trim().ToLower() == nhan_hieu.Trim().ToLower()).Select(q => q.id).SingleOrDefault();
                        var loai_san_pham = itemForm[3].value.ToString().Trim() ?? "";
                        model.ten_loai_san_pham = loai_san_pham;
                        model.db.id_loai_san_pham = repo._context.sys_loai_san_phams.Where(q => q.code.Trim().ToLower() == loai_san_pham.Trim().ToLower()).Select(q => q.id).SingleOrDefault();
                        var don_vi_tinh = itemForm[4].value.ToString().Trim() ?? "";
                        model.ten_don_vi_tinh = don_vi_tinh;
                        model.db.id_don_vi_tinh = repo._context.sys_don_vi_tinhs.Where(q => q.code.Trim().ToLower() == don_vi_tinh.Trim().ToLower()).Select(q => q.id).SingleOrDefault();
                        var note = itemForm[5].value.ToString().Trim() ?? "";
                        model.db.note = note;
                        error = CheckErrorImport(model, i + 1, error);
                        list_model.Add(model);
                        count_error = count_error + 1;
                    }
                    if (string.IsNullOrEmpty(error))
                    {
                        //thành công không lỗi
                        foreach (var item in list_model)
                        {
                            item.db.id = Guid.NewGuid().ToString();
                            item.db.ma_san_pham = getCode();
                            item.db.create_by = getUserId();
                            item.db.create_date = DateTime.Now;
                            item.db.update_by = getUserId();
                            item.db.update_date = DateTime.Now;
                            item.db.status_del = 1;
                            await repo.insert(item);
                        }
                        return Json("1");
                    }
                    else
                    {
                        var path_error = get_path_file(nameSheet, error, _appsetting.folder_path);
                        try
                        {
                            var memory = new MemoryStream();
                            using (var stream = new FileStream(path_error, FileMode.Open))
                            {
                                await stream.CopyToAsync(memory);
                            }
                            memory.Position = 0;
                            return Json(path_error);
                        }
                        catch (Exception ex)
                        {
                            var count = count_error;
                            Console.WriteLine(ex);
                            return Json("-1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    var count = count_error;
                    Console.WriteLine(ex);
                    return Json("-1");
                }
            }
            else
            {
                return Json("-1");
            }
        }
        public async Task<FileStreamResult> exportToExcel(string search, int status_del, long id_loai_san_pham, long id_nhan_hieu)
        {
            var excel = new ExcelHelper(_appsetting);
            search = search ?? "";
            var query = repo.FindAll()
                    .Where(q => q.db.id_loai_san_pham == id_loai_san_pham || id_loai_san_pham == -1)
                    .Where(q => q.db.id_nhan_hieu == id_nhan_hieu || id_nhan_hieu == -1)
                    .Where(q => q.db.status_del == status_del)
                    .Where(q => q.db.ten_san_pham.Contains(search) || q.db.ma_san_pham.Contains(search) || search == "");
            string[] header = new string[]
            {
                "STT","Mã sản phẩm","Tên sản phẩm","Nhãn hiệu","Loại sản phẩm","Đơn vị tính","Ghi chú"
            };
            string[] listKey = new string[]
            {
              "db.ma_san_pham","db.ten_san_pham", "ten_nhan_hieu","ten_loai_san_pham","ten_don_vi_tinh","db.note"
            };
            string file = "";
            try
            {
                file = excel.exportExcel(query, null, new List<string[]> { header }, listKey, new List<NPOI.SS.Util.CellRangeAddress>(), "Danh sách sản phẩm", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            if (!string.IsNullOrEmpty(file))
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(file, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, excel.GetContentType(file), Path.Combine(file));
            }
            return null;
        }
    }
}
