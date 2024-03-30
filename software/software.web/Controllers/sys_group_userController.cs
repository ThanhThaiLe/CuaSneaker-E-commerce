using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using software.common.BaseClass;
using software.common.ControllerBase;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.repo.DataAccess;
using software.repo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace software.web.Controllers
{
    public partial class sys_group_userController : BaseAuthenticationController
    {
        public sys_group_user_repo repo;
        public sys_group_userController(IUserService userService, SoftwareDefautTable context) : base(userService)
        {
            repo = new sys_group_user_repo(context);
        }
        public IActionResult getListUse()
        {
            return Json("");
        }
        public IActionResult getListItem([FromBody] JObject json)
        {
            var model = repo.FindAllItem(json.GetValue("id").ToString()).ToList();
            return Json(model);
        }

        public IActionResult getListRole([FromBody] JObject json)
        {
            var model = repo.FindAllRole(json.GetValue("id").ToString()).ToList();
            return Json(model);
        }
        public IActionResult getListRoleFull([FromBody] JObject json)
        {
            var user_id = getUserId();
            var model = ListController.list;
            model = model.Where(q => (q.type_user ?? 1) == 1).ToList();
            var list_dynamic = new List<dynamic>();
            for (int i = 0; i < model.Count; i++)
            {
                var listRole = model[i].list_role.Select(q => new
                {
                    role = q,
                    controller_name = model[i].translate,

                });
                list_dynamic.AddRange(listRole);
            }
            return Json(list_dynamic);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_group_user_model>(json.GetValue("data").ToString());
            var check = checkModelStateCreate(model);
            if (!check)
            {
                return generateError();
            }
            model.db.id = Guid.NewGuid().ToString();
            model.db.create_date = DateTime.Now;
            model.db.update_date = DateTime.Now;
            model.db.status_del = 1;
            model.db.create_by = getUserId();
            model.db.update_by = getUserId();
            await repo.insert(model);
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> edit([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_group_user_model>(json.GetValue("data").ToString());

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
        public async Task<IActionResult> delete([FromBody] JObject json)
        {
            var id = json.GetValue("id").ToString();
            var status = json.GetValue("status").ToString();
            repo.delete_status(id, getUserId(), int.Parse(status));
            return Json("");
        }
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
                var query = repo.FindAll().Where(q => q.db.name.Contains(search) && q.db.status_del == status_del);
                var count = query.Count();
                var dataList = await Task.Run(() => query.OrderByDescending(q => q.db.update_date).Skip(param.Start).Take(param.Length).ToList());
                DTResult<sys_group_user_model> result = new DTResult<sys_group_user_model>
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