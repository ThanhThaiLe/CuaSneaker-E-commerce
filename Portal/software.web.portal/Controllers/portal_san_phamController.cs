using domain.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using software.common.ControllerBase;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.repo.portal.Repo;
using System.Data.Entity;
namespace software.web.portal.Controllers
{
    public partial class portal_san_phamController : BaseAuthenticationController
    {
        private portal_home_repo repo;
        private AppSetting _appsetting;
        public portal_san_phamController(IUserService userService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new portal_home_repo(context);
            _appsetting = appsetting.Value;
        }
        public IActionResult get_list_san_pham_page([FromBody] JObject json)
        {
            var page = int.Parse(json.GetValue("page").ToString());
            var list = repo.FindAllSanPham();
            var list_san_pham = list.Skip(page * 10).Take(10).ToList();
            var total = list.Count();
            var result = new
            {
                list_san_pham = list_san_pham,
                total_item = total,
                total_page = Math.Round((decimal)(total / 10)) + (total % 10 == 0 ? 0 : 1),
            };
            return Json(result);
        }
        public IActionResult get_list_san_pham()
        {
            var result = repo.FindAllSanPham();
            return Json(result);
        }
        public IActionResult get_detail_san_pham([FromBody] JObject json)
        {
            var ma_san_pham = json.GetValue("ma_san_pham").ToString();
            var san_pham = repo.FindAllSanPham().FirstOrDefault(q => q.ma_san_pham == ma_san_pham);
            san_pham.list_san_pham_detail = repo.FindAllSanPhamDetail().Where(q => q.id_san_pham == san_pham.id).ToList();
            foreach (var item in san_pham.list_san_pham_detail)
            {
                item.list_file = repo.FindAllFileSanPham().Where(q => q.db.id_parent == item.id + "").Where(q => q.db.status_del == 1).ToList();
                item.list_size = repo._context.sys_sizes.Where(q => item.id_size.Contains(q.id.ToString())).Where(q => q.status_del == 1).Select(q => new sys_common_number_model
                {
                    id = q.id,
                    name = q.name,
                    code = q.code,
                }).ToList();
            }

            san_pham.list_color = san_pham.list_san_pham_detail.Select(q => new sys_common_number_model
            {
                id = q.id_color ?? 0,
                name = q.color,
                code = q.color_code,
            }).ToList();
            return Json(san_pham);
        }
    }
}
