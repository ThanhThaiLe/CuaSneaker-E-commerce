using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using software.database.Provider;

namespace software.common.BaseClass
{
    public class SoftwareAuthorize : ActionFilterAttribute
    {
        private readonly SoftwareDefautTable _context;
        private IMemoryCache _memoryCache;
        public SoftwareAuthorize(SoftwareDefautTable context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }



        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string actionName = context.RouteData.Values["action"].ToString().ToLower();
            string controllerName = context.RouteData.Values["controller"].ToString().ToLower();
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<SoftwareAuthorize>>();
            logger.LogInformation($"Controller: {controllerName}, Action: {actionName}");
            var reponse = context.HttpContext.Response.StatusCode;
            var isValid = false;
            // controller public non login
            //if (controllerName == "" && actionName == "")
            //{
            //    base.OnActionExecuting(context);
            //    return;
            //}
            if (controllerName == "sys_home")
            {
                base.OnActionExecuting(context);
                return;
            }
            if (controllerName == "FileManager")
            {
                base.OnActionExecuting(context);
                return;
            }
            // nếu chưa login thì sẽ dùng những action của controller ở trạng thái không cho phép đăng nhập
            if (ListController.listpublicNonactioncontroller.Contains(controllerName + ";" + actionName))
            {
                base.OnActionExecuting(context);
                return;
            }
            // nếu login thì sẽ dùng tất cả các action của controller
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new ContentResult { Content = "401" };
                return;

            }
            if (ListController.listpublicactioncontroller.Contains(controllerName + ";" + actionName))
            {
                base.OnActionExecuting(context);
                return;
            }
            // nếu login thì sẽ dùng tất cả các action của controller
            var check_role = checkRole(context.HttpContext, controllerName, actionName);
            if (check_role == false)
            {
                context.HttpContext.Response.StatusCode = 403;
                context.Result = new ContentResult { Content = "403" };
                return;

            }
            base.OnActionExecuting(context);

        }
        private bool checkRole(HttpContext httpContext, string controllerName, string actionName)
        {
            List<string> cacheActionControllerUser;
            var username = httpContext.User.Identity.Name;
            var cachekey = "softwareAuthorizeControllerAction" + username;
            if (!_memoryCache.TryGetValue(cachekey, out cacheActionControllerUser))
            {
                var userid = username;
                var type = _context.sys_users.Where(q => q.id == userid).Select(q => q.type).SingleOrDefault();
                var listresult = new List<string>();
                if (type == 1)
                {
                    var listGroupId = _context.sys_group_user_details
                        .Where(q => _context.sys_group_users.Where(t => t.id == q.id_group_user).Select(q => q.status_del).SingleOrDefault() == 1)
                        .Where(t => t.user_id == userid).Select(q => q.id_group_user).ToList();
                    var listRole = _context.sys_group_user_rolers.Where(q => listGroupId.Contains(q.id_group_user)).ToList();
                    var listcontrollerName = listRole.Select(q => q.controller_name).Distinct().ToList();
                    var listroleId = listRole.Select(q => q.id_controller_role).Distinct().ToList();
                    for (int i = 0; i < ListController.list.Count(); i++)
                    {
                        if (listcontrollerName.ToList().Contains(ListController.list[i].translate))
                        {
                            for (int j = 0; j < ListController.list[i].list_role.Count(); j++)
                            {
                                if (listroleId.Contains(ListController.list[i].list_role[j].id))
                                {
                                    listresult.AddRange(ListController.list[i].list_role[j].list_controller_action.Select(q => q.ToLower()));
                                }
                            }
                        }
                    }
                }
                else
                {
                    var role = ListController.list.Where(q => q.type_user == 2).ToList();
                    for (int i = 0; i < role.Count(); i++)
                    {
                        for (int j = 0; j < role[i].list_role.Count(); j++)
                        {
                            listresult.AddRange(role[i].list_role[j].list_controller_action.Select(q => q.ToLower()));
                        }
                    }
                }
                cacheActionControllerUser = listresult;
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));
                _memoryCache.Set(cachekey, cacheActionControllerUser, cacheEntryOptions);
            }
            if (!cacheActionControllerUser.Contains(controllerName + ";" + actionName)) return false;

            return true;

        }
    }
}
