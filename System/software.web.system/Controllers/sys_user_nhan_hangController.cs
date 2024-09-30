using Microsoft.Extensions.Options;
using software.common.Common;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.repo.Repo;

namespace software.web.Controllers
{
    public partial class sys_user_nhan_hangController : common.ControllerBase.BaseAuthenticationController
    {
        private sys_user_nhan_hang_repo repo;
        private IMailService _mailService;
        private AppSetting _appsetting;
        public sys_user_nhan_hangController(IUserService userService, IMailService mailService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new sys_user_nhan_hang_repo(context);
            _appsetting = appsetting.Value;
            _mailService = mailService;
        }
    }
}
