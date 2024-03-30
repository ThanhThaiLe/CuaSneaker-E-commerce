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
    public partial class sys_quan_huyenController : common.ControllerBase.BaseAuthenticationController
    {
        private sys_quan_huyen_repo repo;
        private AppSetting _appsetting;
        public sys_quan_huyenController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new sys_quan_huyen_repo(context);
            _appsetting = appsetting.Value;
        }
        public IActionResult getListUse()
        {
            var result = repo._context.sys_quan_huyens.Where(q => q.status_del == 1).Select(q => new sys_common_number_model()
            {
                id = q.id,
                name = q.ten,
                id_tinh = q.id_tinh,
            }).ToList();
            return Json(result);
        }
        public IActionResult getListUseWithIdTinhThanh([FromBody] JObject json)
        {
            var id_tinh_thanh = json.GetValue("id_tinh_thanh").ToString();
            var result = repo._context.sys_quan_huyens.Where(q => q.id_tinh == long.Parse(id_tinh_thanh)).Where(q => q.status_del == 1).Select(q => new sys_common_number_model()
            {
                id = q.id,
                name = q.ten,
            }).ToList();
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_quan_huyen_model>(json.GetValue("data").ToString());
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
            var model = JsonConvert.DeserializeObject<sys_quan_huyen_model>(json.GetValue("data").ToString());
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
                    .Where(q => q.db.ten.Contains(search) || q.db.ten_khong_dau.Contains(search) || search == "");
                var count = query.Count();
                var dataList = await Task.Run(() => query.OrderByDescending(q => q.db.update_date).Skip(param.Start).Take(param.Length).ToList());
                DTResult<sys_quan_huyen_model> result = new DTResult<sys_quan_huyen_model>
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

        public async Task<FileStreamResult> exportToExcel(string search, int status_del)
        {
            var excel = new ExcelHelper(_appsetting);
            search = search ?? "";
            var query = repo.FindAll().Where(q => q.db.ten.Contains(search) || q.db.ten_khong_dau.Contains(search) || search == "" && q.db.status_del == status_del).OrderByDescending(q => q.db.update_date);
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
