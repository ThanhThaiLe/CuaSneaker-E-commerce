using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using software.common.Common;
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
    public partial class sys_ngan_hangController : common.ControllerBase.BaseAuthenticationController
    {
        private sys_ngan_hang_repo repo;
        private AppSetting _appsetting;
        public sys_ngan_hangController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new sys_ngan_hang_repo(context);
            _appsetting = appsetting.Value;
        }
        public IActionResult getListUse()
        {
            var result = repo._context.sys_ngan_hangs.Where(q => q.status_del == 1).Select(q => new sys_common_number_model()
            {
                id = q.id,
                name = q.name,
            }).ToList();
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_ngan_hang_model>(json.GetValue("data").ToString());
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
            var model = JsonConvert.DeserializeObject<sys_ngan_hang_model>(json.GetValue("data").ToString());
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
                var query = repo.FindAll()
                    .Where(q => q.db.status_del == status_del)
                    .Where(q => q.db.code.Contains(search) || q.db.name.Contains(search) || search == "");
                var count = query.Count();
                var dataList = await Task.Run(() => query.OrderByDescending(q => q.db.update_date).Skip(param.Start).Take(param.Length).ToList());
                DTResult<sys_ngan_hang_model> result = new DTResult<sys_ngan_hang_model>
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

            string file = newpath + "\\sys_ngan_hang.xlsx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(file);
            System.IO.File.WriteAllBytes(file, fileBytes);
            MemoryStream ms = new MemoryStream(fileBytes);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "sys_ngan_hang.xlsx");
        }
        [HttpPost]
        public async Task<IActionResult> ImportFormExcel()
        {
            var error = "";
            IFormFile file = Request.Form.Files[0];
            var nameSheet = "DonViTinh";
            if (file.Length > 0)
            {
                var count_error = 0;
                try
                {
                    var list_row = handleImportExcelName(file, nameSheet);
                    var list_model = new List<sys_ngan_hang_model>();
                    for (int i = 0; i < list_row.Count(); i++)
                    {
                        var itemForm = list_row[i].list_cell.ToList();
                        var model = new sys_ngan_hang_model();
                        var stt = itemForm[0].value.ToString().Trim() ?? "";
                        var code = itemForm[1].value.ToString().Trim() ?? "";
                        var name = itemForm[2].value.ToString().Trim() ?? "";
                        var note = itemForm[3].value.ToString().Trim() ?? "";


                        // map data
                        model.db.code = code;
                        model.db.name = name;
                        model.db.note = note;

                        error = CheckErrorImport(model, i + 1, error);
                        list_model.Add(model);
                    }
                    if (string.IsNullOrEmpty(error))
                    {
                        //thành công không lỗi
                        foreach (var item in list_model)
                        {
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

        public async Task<FileStreamResult> exportToExcel(string search, int status_del)
        {
            var excel = new ExcelHelper(_appsetting);
            search = search ?? "";
            var query = repo.FindAll().Where(q => q.db.name.Contains(search) || search == "" && q.db.status_del == status_del).OrderByDescending(q => q.db.update_date);
            string[] header = new string[]
            {
                "STT","Mã đơn vị tính","Tên đơn vị tính","Ghi chú"
            };
            string[] listKey = new string[]
            {
              "db.code", "db.name","db.note"
            };
            string file = "";
            try
            {
                file = excel.exportExcel(query, null, new List<string[]> { header }, listKey, new List<NPOI.SS.Util.CellRangeAddress>(), "Danh sách đơn vị tính", true);
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
