using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using software.common.ControllerBase;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.repo.portal.Repo;
using System.Linq;

namespace software.web.portal.Controllers
{
    public partial class portal_paymentController : BaseAuthenticationController
    {
        private portal_home_repo repo;
        private AppSetting _appsetting;
        public portal_paymentController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new portal_home_repo(context);
            _appsetting = appsetting.Value;
        }
        public IActionResult getInfoReceiver()
        {
            var id_user = getUserId();
            var result = repo._context.sys_user_nhan_hangs.Where(q => q.id_user == id_user).SingleOrDefault();
            return Json(result);
        }
        public IActionResult register_don_hang()
        {
            var id_user = getUserId();
            var result = repo._context.sys_user_nhan_hangs.Where(q => q.id_user == id_user).SingleOrDefault();
            return Json(result);
        }
    }
}
