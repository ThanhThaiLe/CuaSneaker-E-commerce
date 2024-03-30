using software.common.ControllerBase;
using software.common.Service;
using software.database.Provider;

namespace software.web.Controllers
{
    public partial class sys_menuController : BaseAuthenticationController
    {
        SoftwareDefautTable context;
        public sys_menuController(IUserService userService, SoftwareDefautTable _context) : base(userService)
        {
            context = _context;
        }

    }
}
