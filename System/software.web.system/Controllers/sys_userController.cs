using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using software.common.Common;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.repo.DataAccess;
using software.repo.Repo;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace software.web.Controllers
{
    public partial class sys_userController : common.ControllerBase.BaseAuthenticationController
    {
        private sys_user_repo repo;
        private IMailService _mailService;
        private AppSetting _appsetting;
        public sys_userController(IUserService userService, IMailService mailService, SoftwareDefautTable context, IOptions<AppSetting> appsetting) : base(userService)
        {
            repo = new sys_user_repo(context);
            _appsetting = appsetting.Value;
            _mailService = mailService;
        }
        [HttpPost]
        public IActionResult authenticate([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_user_authentication_model>(json.GetValue("data").ToString());

            var check = checkModelStateAuthenticate(model);
            if (!check)
            {
                return generateError();
            }
            var user = repo._context.sys_users.Where(q => q.email == model.email).SingleOrDefault();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            HttpContext.Session.Remove("CaptchaCode");
            return Json(new
            {
                id = user.id,
                user_name = user.user_name,
                email = user.email,
                type = user.type,
                status_del = user.status_del,
                token = tokenString,
            });
        }
        public IActionResult getUserLogin()
        {
            var result = repo._context.sys_users.Where(q => q.id == getUserId()).SingleOrDefault();
            return Json(new
            {
                id = result.id,
                user_name = result.user_name,
                full_name = result.full_name,
                email = result.email,
                type = result.type,
                status_del = result.status_del,
            });
        }
        [HttpPost]
        public async Task<IActionResult> register([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<sys_user_register_model>(json.GetValue("user").ToString());

            var check = checkModelStateRegister(model);
            if (!check)
            {
                return generateError();
            }
            var item = new sys_user_model();
            item.db.id = Guid.NewGuid().ToString();
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(model.password, out passwordHash, out passwordSalt);
            item.db.PasswordHash = passwordHash;
            item.db.PasswordSalt = passwordSalt;
            item.db.last_name = model.last_name;
            item.db.first_name = model.first_name;
            item.db.full_name = model.last_name + " " + model.first_name;
            item.db.email = model.email;
            item.db.user_name = model.email;
            item.db.status_del = 3;
            item.db.type = 1;
            item.db.create_date = DateTime.Now;
            item.db.update_by = getUserId();
            await repo.insert(item);
            var code_template_mail = "2";
            var type_mail = repo._context.sys_type_mails.Where(q => q.code == code_template_mail).SingleOrDefault();
            var template_mail = repo._context.sys_template_mails.Where(q => q.id_type == type_mail.id).SingleOrDefault();
            var body = template_mail.template ?? "";
            body = body.Replace("@@user_name@@", item.db.full_name);
            body = body.Replace("@@url_update_status@@", "https://" + Request.Host.Value + "/sys_user.ctr/update_status_del?email=" + item.db.email + "&status=" + 1);
            await _mailService.SendMail(new MailRequest
            {
                body = body,
                subJect = type_mail.name,
                toEmail = item.db.email,
                ccEmail = "",
            });
            return Json(item.db.id);
        }
        [HttpGet]
        public IActionResult update_status_del(string email, int status)
        {
            var user = repo._context.sys_users.Where(q => q.email == email).SingleOrDefault();
            user.status_del = status;
            repo._context.SaveChanges();
            return Json("");
        }
        [HttpPost]
        public async Task<IActionResult> forgot_pass([FromBody] JObject json)
        {
            var email = json.GetValue("email").ToString();
            var captcha = json.GetValue("captcha").ToString();
            var check = checkModelStateForgotPass(email, captcha);
            if (!check)
            {
                return generateError();
            }
            var user = repo.FindAll().Where(q => q.db.email == email).SingleOrDefault();
            var rnd = new Random();
            var code = rnd.Next(11111, 99999).ToString();
            user.db.token_reset_pass = DateTime.Now.Ticks.ToString();
            user.db.expiration_date_reset_pass = DateTime.Now;
            repo._context.SaveChanges();
            var code_template_mail = "5";
            var type_mail = repo._context.sys_type_mails.Where(q => q.code == code_template_mail).SingleOrDefault();
            var template_mail = repo._context.sys_template_mails.Where(q => q.id_type == type_mail.id).SingleOrDefault();
            var encryptconfirmparam = CMAESCrypto.EncryptText(user.db.id + "@@" + user.db.token_reset_pass);
            // encryptconfirmparam = encryptconfirmparam.Replace("%", "");
            var body = template_mail.template ?? "";
            body = body.Replace("@@link_home@@", "https://" + Request.Host.Value);
            body = body.Replace("@@link_dang_nhap@@", "https://" + Request.Host.Value + "sign-in");
            body = body.Replace("@@url@@", "https://" + Request.Host.Value);
            body = body.Replace("@@user_name@@", user.db.full_name);
            body = body.Replace("@@url_reset@@", "https://" + Request.Host.Value + "/reset-password?token=" + HttpUtility.UrlEncode(encryptconfirmparam));
            await _mailService.SendMail(new MailRequest
            {
                body = body,
                subJect = type_mail.name,
                toEmail = user.db.email,
                ccEmail = "",
            });
            return generateSuscess();
        }
        [HttpPost]
        public IActionResult checkResetPass([FromBody] JObject json)
        {
            var q = json.GetValue("token").ToString();
            try
            {
                var decrypto = CMAESCrypto.DecryptText(q);
                var id = decrypto.Replace("confirm", "").Split("@@")[0];
                var token = decrypto.Replace("confirm", "").Split("@@")[1];
                var update = repo._context.sys_users.Where(q => q.id == id).SingleOrDefault();
                if (update.expiration_date_reset_pass.Value.AddMinutes(15).Ticks < DateTime.Now.Ticks)
                {
                    return Json(false);
                }
                if (update.token_reset_pass != token)
                {
                    return Json(false);
                }
                else
                {
                    return Json(CMAESCrypto.EncryptText(id));
                }
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
        [HttpPost]
        public async Task<IActionResult> changePasswordNonLogin([FromBody] JObject json)
        {
            var password = json.GetValue("password").ToString();
            var repassword = json.GetValue("repassword").ToString();
            var iduser = "";
            try
            {
                iduser = json.GetValue("iduser").ToString();
            }
            catch (Exception e)
            {
            }

            var idUser = CMAESCrypto.DecryptText(iduser);
            var user = repo._context.sys_users.Where(q => q.id == idUser).SingleOrDefault();
            if (user.token_reset_pass == null)
            {
                ModelState.AddModelError("token", "auth.token_da_het_han");
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "error.requied");
            }
            else
            {
                if (password.Length < 8)
                {
                    ModelState.AddModelError("password", "auth.mat_khau_phai_lon_hon_8_ky_ty");
                }
            }
            if (string.IsNullOrEmpty(repassword))
            {
                ModelState.AddModelError("repassword", "error.requied");
            }
            else
            {
                if (password != repassword && password != "")
                {
                    ModelState.AddModelError("repassword", "auth.mat_khau_khong_khop");
                }
            }
            if (!ModelState.IsValid)
            {
                return generateError();
            }
            sys_user_model model = new sys_user_model();
            if (!string.IsNullOrEmpty(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(model.password, out passwordHash, out passwordSalt);
                model.db.PasswordHash = passwordHash;
                model.db.PasswordSalt = passwordSalt;
                await repo.updatePass(model);
            }
            return Json("");
        }

    }
}
