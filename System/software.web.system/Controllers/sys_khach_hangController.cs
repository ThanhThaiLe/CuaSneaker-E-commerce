using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.repo.DataAccess;
using software.repo.Repo;
namespace software.web.Controllers
{
    public partial class sys_khach_hangController : common.ControllerBase.BaseAuthenticationController
    {
        private sys_user_repo repo;
        private AppSetting _appsetting;
        public sys_khach_hangController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new sys_user_repo(context);
            _appsetting = appsetting.Value;
        }

        [HttpPost]
        public IActionResult initeData()
        {
            var item = new sys_khach_hang_model();
            item.id = Guid.NewGuid().ToString();
            item.avatar = "FileManeger/Download/?filename=%5cimage_upload%5c638232396801965858.jpg";
            item.name = "New Contact";
            item.title = "New Contact";
            item.email = "New Contact";
            item.phone = "New Contact";
            item.address = "New Contact";
            item.birthday = "";
            item.notes = "";
            item.background = "FileManeger/Download/?filename=%5cimage_upload%5c638232396801965858.jpg";
            return Json(item);

        }
        public IActionResult getContacts()
        {
            var result = repo._context.sys_users.Where(q => q.status_del == 1).Select(q => new sys_khach_hang_model()
            {
                id = q.id,
                name = q.full_name,
                avatar = "FileManeger/Download/?filename=%5cimage_upload%5c638232396801965858.jpg",
                title = "New Contact",
                email = "New Contact",
                phone = "New Contact",
                address = "New Contact",
                birthday = "",
                notes = "",
                background = "FileManeger/Download/?filename=%5cimage_upload%5c638232396801965858.jpg",
            }).ToList();
            return Json(result);
        }
        public IActionResult getUserLogin()
        {
            var user = repo._context.sys_users.Where(q => q.id == getUserId()).Select(q => new sys_user_login_model()
            {
                id = q.id,
                avatar_path = q.email,
                last_name = q.last_name,

            }).SingleOrDefault();
            return Json(user);

        }
    }
}
