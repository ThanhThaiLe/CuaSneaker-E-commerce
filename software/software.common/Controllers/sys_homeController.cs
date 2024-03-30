using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using software.common.BaseClass;
using software.common.ControllerBase;
using software.common.Service;
using software.database.Provider;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace software.web.Controllers
{
    public partial class sys_homeController : BaseAuthenticationController
    {
        SoftwareDefautTable context;
        public sys_homeController(IUserService userService, SoftwareDefautTable _context) : base(userService)
        {
            context = _context;
        }

        public async Task<ActionResult> checkLogin()
        {
            return generateSuscess();
        }
        public async Task<ActionResult> getListRoleFull()
        {
            var user_id = getUserId();
            var model = ListController.list;
            model = model.Where(q => (q.type_user ?? 1) == 1).ToList();
            var listDynamic = new List<dynamic>();
            for (int i = 0; i < model.Count; i++)
            {
                var listRole = model[i].list_role.Select(q => new
                {
                    role = q,
                    controller_name = model[i].translate
                });
                listDynamic.AddRange(listRole);
            }
            return Json(listDynamic);
        }
        public async Task<ActionResult> getModule()
        {

            var user_id = getUserId();

            var type_user = context.sys_users.Where(q => q.id == user_id).Select(q => q.type).SingleOrDefault();
            var model = JsonConvert.DeserializeObject<List<ControllerAppModel>>(JsonConvert.SerializeObject(ListController.list));
            var groupId = context.sys_group_user_details
                //.Where(q => q.user_id == user_id)
                .Select(q => q.id_group_user).ToList();
            var modelFilerRole = model;
            if (type_user == 1)
            {
                model.ForEach(menu =>
                {
                    menu.list_role = context.sys_group_user_rolers.Where(q => groupId.Contains(q.id_group_user)).ToList()
                    .Where(q => q.id_controller_role.Split(";")[0] == menu.controller).Select(q => new ControllerRoleModel
                    {
                        id = q.id_controller_role,
                        name = q.role_name,
                        list_controller_action = new List<string>()
                        {
                            q.id_controller_role,
                        }

                    }).ToList();
                });

            }
            else
            {

            }
            var listDynamic = new List<dynamic>();
            for (int i = 0; i < modelFilerRole.Count; i++)
            {
                var count = 0;
                var countreturn = 0;
                var item = new
                {
                    menu = modelFilerRole[i],
                    badge_approval = count,
                    badge = countreturn,
                };
                listDynamic.Add(item);
            }
            if (type_user == 2)
            {
                ControllerAppModel controller = new ControllerAppModel();
                var item1 = new
                {
                    menu = controller,
                    badge_approval = 0,
                    badge_return = 0,
                };
            }
            return Json(listDynamic);
        }
    }
}
