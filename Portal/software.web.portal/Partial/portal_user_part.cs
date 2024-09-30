using Microsoft.AspNetCore.Http;
using software.common.Model;
using software.entity.system;
using software.repo.DataAccess;
using System.Text;
using System.Text.RegularExpressions;

namespace software.web.Controllers
{
    partial class portal_userController
    {
        public static ControllerAppModel declare = new ControllerAppModel()
        {
            controller = "portal_user",
            icon = "heroicons_outline:home",
            icon_image = "assets/images/logo/logo.jpg",
            module = "system",
            id = "portal_user",
            title = "portal_user",
            url = "/portal_user_index",
            type = "item",
            translate = "NAV.portal_user",
            is_show_all_user = true,

            list_public_Non_action_controller = new List<string>()
            {
                        "portal_user;create",
                        "portal_user;register",
                        "portal_user;authenticate",
                        "portal_user;forgot_pass",
                        "portal_user;update_status_del",
                        "portal_user;checkResetPass",
                        "portal_user;changePasswordNonLogin",
            },
            list_controller_action_public = new List<string>()
            {
                        "portal_user;getUserLogin",
            },
            list_role = new List<ControllerRoleModel>()
            {
                new ControllerRoleModel()
                {
                    id="portal_user;create",
                    name="common.create",
                    list_controller_action = new List<string>()
                    {
                        "portal_user;create",
                    }
                },
                new ControllerRoleModel()
                {
                    id="portal_user;edit",
                    name="common.edit",
                    list_controller_action = new List<string>()
                    {
                        "portal_user;edit",
                    }
                },
                new ControllerRoleModel()
                {
                    id="portal_user;delete",
                    name="common.delete",
                    list_controller_action = new List<string>()
                    {
                        "portal_user;delete",
                    }
                },
                new ControllerRoleModel()
                {
                    id="portal_user;list",
                    name="common.list",
                    list_controller_action = new List<string>()
                    {
                        "portal_user;DataHandler",
                    }
                },
            }
        };
        private bool checkModelStateCreate(portal_user_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateEdit(portal_user_model item)
        {
            return checkModelStateCreateEdit(item);
        }
        private bool checkModelStateCreateEdit(portal_user_model item)
        {
            //if (String.IsNullOrEmpty(item.db.id))
            //{
            //    ModelState.AddModelError("db.fullname", "error.requied");
            //}
            return ModelState.IsValid;
        }
        private bool checkModelStateAuthenticate(portal_user_authentication_model item)
        {
            return checkModelStateAuthenticate(ActionEnumForm.create, item);
        }
        private bool checkModelStateAuthenticate(ActionEnumForm action, portal_user_authentication_model model)
        {
            var user = new sys_user_db();
            if (string.IsNullOrEmpty(model.password))
            {
                ModelState.AddModelError("password", "error.requied");
            }
            if (string.IsNullOrEmpty(model.email))
            {
                ModelState.AddModelError("db.email", "error.requied");
            }
            else
            {
                var rgEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                            + "@"
                                            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");

                var checkMail = rgEmail.IsMatch(model.email);
                if (checkMail == false)
                {
                    ModelState.AddModelError("db.email", "error.mail_khong_hop_le");
                }
                else
                {
                    user = repo._context.sys_users.Where(q => q.email == model.email).SingleOrDefault();
                    if (user == null)
                    {
                        ModelState.AddModelError("db.email", "error.mail_khong_ton_tai");
                    }
                    else
                    {
                        if (!VerifyPasswordHash(model.password, user.PasswordHash, user.PasswordSalt))
                        {
                            ModelState.AddModelError("password", "error.mat_khau_khong_chinh_xac");
                        }
                    }
                }
            }
            if (model.show_captcha == 1)
            {
                if (string.IsNullOrEmpty(model.captcha))
                {
                    ModelState.AddModelError("captcha", "error.requied");
                }
                else
                {
                    var captchaCode = HttpContext.Session.GetString("CaptchaCode");
                    if (captchaCode.ToLower() != model.captcha.ToLower())
                    {
                        ModelState.AddModelError("captcha", "error.captcha_khong_chinh_xac");
                    }
                }
            }
            return ModelState.IsValid;
        }
        private bool checkModelStateRegister(portal_user_register_model item)
        {
            return checkModelStateRegister(ActionEnumForm.create, item);
        }
        private bool checkModelStateRegister(ActionEnumForm action, portal_user_register_model model)
        {
            if (string.IsNullOrEmpty(model.last_name))
            {
                ModelState.AddModelError("db.last_name", "error.requied");
            }
            if (string.IsNullOrEmpty(model.first_name))
            {
                ModelState.AddModelError("db.first_name", "error.requied");
            }
            if (string.IsNullOrEmpty(model.password))
            {
                ModelState.AddModelError("password", "error.requied");
            }
            else
            {
                if (model.password.Length < 6)
                {
                    ModelState.AddModelError("password", "error.mat_khau_toi_thieu_6_ky_tu");
                }
            }
            if (string.IsNullOrEmpty(model.email))
            {
                ModelState.AddModelError("db.email", "error.requied");
            }
            else
            {
                var rgEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                            + "@"
                                            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");

                var checkMail = rgEmail.IsMatch(model.email);
                if (checkMail == false)
                {
                    ModelState.AddModelError("db.email", "error.mail_khong_hop_le");
                }
                else
                {

                    var user = repo._context.sys_users.Where(q => q.email == model.email).SingleOrDefault();
                    if (user != null)
                    {
                        ModelState.AddModelError("db.email", "error.mail_da_ton_tai");
                    }
                    //else
                    //{
                    //    if (!VerifyPasswordHash(model.password, user.PasswordHash, user.PasswordSalt))
                    //    {
                    //        ModelState.AddModelError("password", "error.mat_khau_khong_chinh_xac");
                    //    }
                    //}
                }
            }
            if (string.IsNullOrEmpty(model.captcha))
            {
                ModelState.AddModelError("captcha", "error.requied");
            }
            else
            {
                var captchaCode = HttpContext.Session.GetString("CaptchaCode");
                if (captchaCode.ToLower() != model.captcha.ToLower())
                {
                    ModelState.AddModelError("captcha", "error.captcha_khong_chinh_xac");
                }
            }
            return ModelState.IsValid;
        }
        private bool checkModelStateForgotPass(string email, string captcha)
        {
            return checkModelStateForgotPass(ActionEnumForm.create, email, captcha);
        }
        private bool checkModelStateForgotPass(ActionEnumForm action, string email, string captcha)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("db.email", "error.requied");
            }
            else
            {
                var user = repo._context.sys_users.Where(q => q.email == email).SingleOrDefault();
                if (user == null)
                {
                    var rgEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                            + "@"
                                            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");

                    var checkMail = rgEmail.IsMatch(email);
                    if (checkMail == false)
                    {
                        ModelState.AddModelError("db.email", "error.mail_khong_hop_le");
                    }
                }
            }
            if (string.IsNullOrEmpty(captcha))
            {
                ModelState.AddModelError("captcha", "error.requied");
            }
            else
            {
                var captchaCode = HttpContext.Session.GetString("CaptchaCode");
                if (captchaCode.ToLower() != captcha.ToLower())
                {
                    ModelState.AddModelError("captcha", "error.captcha_khong_chinh_xac");
                }
            }
            return ModelState.IsValid;
        }
    }
}
