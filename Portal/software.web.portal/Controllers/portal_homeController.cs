

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using software.common.ControllerBase;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.repo.portal.Repo;

namespace software.web.portal.Controllers
{
    public partial class portal_homeController : BaseAuthenticationController
    {
        private portal_home_repo repo;
        private AppSetting _appsetting;
        public portal_homeController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new portal_home_repo(context);
            _appsetting = appsetting.Value;
        }
        public IActionResult get_list_san_pham()
        {
            var result = repo.FindAllSanPham();
            return Json(result);
        }
    }
}
