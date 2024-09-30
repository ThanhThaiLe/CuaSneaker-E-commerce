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

namespace software.web.Controllers
{
    public partial class sys_bannerController : BaseAuthenticationController
    {
        private sys_banner_repo repo;
        private AppSetting _appsetting;
        public sys_bannerController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new sys_banner_repo(context);
            _appsetting = appsetting.Value;
        }
        public IActionResult getListUse()
        {
            var result = repo._context.sys_banners.Where(q => q.status_del == 1).Select(q => new portal_banner_model
            {
                id = q.id,
                image_web = q.image_web,
                image_mobi = q.image_mobi,
                id_type = q.id_type ?? 0,
                link = q.link,
            }).ToList();
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_banner_model>(json.GetValue("data").ToString());
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
            var model = JsonConvert.DeserializeObject<sys_banner_model>(json.GetValue("data").ToString());
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
        [HttpPost]
        public async Task<IActionResult> DataHandler([FromBody] JObject json)
        {
            try
            {
                var a = Request;
                var param = JsonConvert.DeserializeObject<DTParameters>(json.GetValue("param").ToString());
                var dictionary = new Dictionary<string, string>();
                dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json.GetValue("data").ToString());
                var id_type = int.Parse(dictionary["id_type"]);
                var status_del = int.Parse(dictionary["status_del"]);
                var query = repo.FindAll().Where(q => q.db.id_type == id_type && q.db.status_del == status_del);
                var count = query.Count();
                var dataList = await Task.Run(() => query.OrderByDescending(q => q.db.update_date).Skip(param.Start).Take(param.Length).ToList());
                DTResult<sys_banner_model> result = new DTResult<sys_banner_model>
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
