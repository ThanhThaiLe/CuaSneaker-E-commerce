using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using software.common.ControllerBase;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.entity.system;
using software.repo.DataAccess;
using software.repo.Repo;
using System.Web;

namespace software.web.Controllers
{
    public partial class sys_file_uploadController : BaseAuthenticationController
    {
        private sys_file_upload_repo repo;
        private AppSetting _appsetting;
        public sys_file_uploadController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new sys_file_upload_repo(context);
            _appsetting = appsetting.Value;
        }
        [HttpGet]
        public async Task<IActionResult> update_status(string id)
        {
            await repo.delete(id, 2);
            return Json(id);
        }
        [HttpPost]
        public async Task<ActionResult> upload_file()
        {
            var list_file = new List<sys_file_upload_db>();
            var currentpath = _appsetting.folder_path;
            var request = Request;
            var user_id = User.Identity.Name ?? "nonlogin";
            var controller = Request.Form["controller"].ToString();
            var id_parent = Request.Form["id_parent"].ToString();
            var list = repo._context.sys_file_uploads.Where(q => q.id_parent == id_parent).ToList();
            repo._context.sys_file_uploads.RemoveRange(list);
            repo._context.SaveChanges();
            foreach (var item in Request.Form.Files)
            {
                var tick = Guid.NewGuid().ToString();
                var file_name = item.FileName.Trim('"') + "";
                var host = request.Host.Value;
                if (host.Contains("localhost"))
                {
                    host = "localhost";
                }
                var path = "";
                var count_file = 0;
                path = Path.Combine(_appsetting.folder_path, "file_upload", host, "image_upload", controller, id_parent);
                Thread.Sleep(1);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var pathsave = Path.Combine(path, tick + "." + file_name.Split(".").Last());
                using (System.IO.Stream stream = new FileStream(pathsave, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                sys_file_upload_db db = new sys_file_upload_db();
                db.id = 0;
                db.id_parent = id_parent;
                db.controller = controller;
                db.file_name = file_name;
                var file_path = "FileManager/Download/?filename=" + HttpUtility.UrlEncode(pathsave.Replace(Path.Combine(currentpath, "file_upload", host), ""));
                db.file_path = file_path;
                db.status_del = 1;
                db.file_size = item.Length;
                db.file_type = item.ContentType;
                await repo.insert(db);
                list_file.Add(db);
            }
            return Json(list_file);
        }
        public IActionResult get_list_file([FromBody] JObject json)
        {
            var id_parent = json.GetValue("id_parent").ToString();
            var controller = json.GetValue("controller").ToString();
            var result = repo.FindAll().Where(q => q.db.controller == controller && q.db.id_parent == id_parent).ToList();
            return Json(result);
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
                var id_parent = dictionary["id_parent"];
                var controller = dictionary["controller"];
                var query = repo.FindAll().Where(q => q.db.controller == controller && q.db.id_parent == id_parent);
                var count = query.Count();
                var dataList = await Task.Run(() => query.OrderByDescending(q => q.db.update_date).Skip(param.Start).Take(param.Length).ToList());
                DTResult<sys_file_upload_model> result = new DTResult<sys_file_upload_model>
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
    }
}
