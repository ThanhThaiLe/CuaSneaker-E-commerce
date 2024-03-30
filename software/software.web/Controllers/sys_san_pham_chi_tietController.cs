using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class sys_san_pham_chi_tietController : BaseAuthenticationController
    {
        private sys_san_pham_chi_tiet_repo repo;
        private AppSetting _appsetting;
        public sys_san_pham_chi_tietController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new sys_san_pham_chi_tiet_repo(context);
            _appsetting = appsetting.Value;
        }
        public IActionResult getListUse()
        {
            var result = repo._context.sys_san_pham_chi_tiets.Where(q => q.status_del == 1).Select(q => new sys_san_pham_chi_tiet_item_model
            {
                id = q.id,
                mo_ta = q.mo_ta,
                hinh_anh = q.hinh_anh,
                is_khuyen_mai = q.is_khuyen_mai ?? false,
                is_noi_bac = q.is_noi_bac ?? false,
                gia_ban = q.gia_ban ?? 0,
            }).ToList();
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_san_pham_chi_tiet_model>(json.GetValue("data").ToString());
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
            generate_qr_code(model);
            await repo.insert(model);
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> edit([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_san_pham_chi_tiet_model>(json.GetValue("data").ToString());
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
                var query = repo.FindAll().Where(q => q.db.status_del == status_del);
                var count = query.Count();
                var dataList = await Task.Run(() => query.OrderByDescending(q => q.db.update_date).Skip(param.Start).Take(param.Length).ToList());
                dataList.ForEach(q =>
                {
                    q.list_file = repo._context.sys_file_uploads.Where(d => d.id_parent == q.db.id + "").ToList();
                });
                DTResult<sys_san_pham_chi_tiet_model> result = new DTResult<sys_san_pham_chi_tiet_model>
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

            string file = newpath + "\\sys_san_pham_chi_tiet.xlsx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(file);
            System.IO.File.WriteAllBytes(file, fileBytes);
            MemoryStream ms = new MemoryStream(fileBytes);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "sys_san_pham_chi_tiet.xlsx");
        }
        [HttpPost]
        public async Task<IActionResult> ImportFormExcel()
        {
            var error = "";
            IFormFile file = Request.Form.Files[0];
            var nameSheet = "SanPhamChiTiet";
            if (file.Length > 0)
            {
                var count_error = 0;
                try
                {
                    var list_row = handleImportExcelName(file, nameSheet);
                    var list_model = new List<sys_san_pham_chi_tiet_model>();
                    for (int i = 0; i < list_row.Count(); i++)
                    {
                        var itemForm = list_row[i].list_cell.ToList();
                        var model = new sys_san_pham_chi_tiet_model();
                        var stt = itemForm[0].value.ToString().Trim() ?? "";
                        var ma_san_pham = itemForm[1].value.ToString().Trim() ?? "";
                        model.ma_san_pham = ma_san_pham;
                        model.db.id_san_pham = repo._context.sys_san_phams.Where(q => q.ma_san_pham.Trim().ToLower() == model.ma_san_pham.Trim().ToLower()).Select(q => q.id).SingleOrDefault();

                        var gia_ban = itemForm[2].value.ToString().Trim() ?? "";
                        if (!string.IsNullOrEmpty(gia_ban))
                        {
                            model.db.gia_ban = decimal.Parse(gia_ban);
                        }
                        else
                        {
                            model.db.gia_ban = 0;
                        }

                        var ma_mau = itemForm[3].value.ToString().Trim() ?? "";
                        model.color_code = ma_mau;
                        model.db.id_color = repo._context.sys_colors.Where(q => q.code.Trim().ToLower() == model.color_code.Trim().ToLower()).Select(q => q.id).SingleOrDefault();

                        var ma_size = itemForm[4].value.ToString().Trim() ?? "";
                        model.size = ma_size;
                        model.list_code_size = ma_size.Split(",").Select(q => q.Trim().ToLower()).ToList();
                        model.list_id_size = repo._context.sys_sizes.Where(q => model.list_code_size.Contains(q.code.Trim().ToLower())).Select(q => q.id).ToList();
                        model.db.id_size = string.Join(",", model.list_id_size);

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
                            item.db.id = 0;
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
    }
}
