using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.database.System;
using software.repo.Repo;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace software.web.Controllers
{
    public partial class sys_tag_userController : common.ControllerBase.BaseAuthenticationController
    {
        private sys_tag_user_repo repo;
        private AppSetting _appsetting;
        public sys_tag_userController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new sys_tag_user_repo(context);
            _appsetting = appsetting.Value;
        }
        public IActionResult getListUse()
        {
            var result = repo._context.sys_tag_users.Where(q => q.status_del == 1 && q.id_user == getUserId()).Select(q => new sys_common_string_model()
            {
                id = q.id,
                name = q.title,
            }).ToList();
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_tag_user_db>(json.GetValue("data").ToString());
            var check = checkModelStateCreate(model);
            if (!check)
            {
                return generateError();
            }
            model.status_del = 1;
            model.create_date = DateTime.Now;
            model.update_date = DateTime.Now;
            model.create_by = getUserId();
            model.update_by = getUserId();
            model.id_user = getUserId();
            await repo.insert(model);
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> edit([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_tag_user_db>(json.GetValue("tag").ToString());
            var id = json.GetValue("id").ToString();
            var check = checkModelStateCreate(model);
            if (!check)
            {
                return generateError();
            }
            model.status_del = 1;
            model.update_date = DateTime.Now;
            model.update_by = getUserId();
            await repo.update(model);
            return Json(model);
        }
        [HttpDelete]
        public async Task<IActionResult> update_status(string id)
        {
            await repo.delete(id, 2);
            return Json(id);
        }
    }
}
