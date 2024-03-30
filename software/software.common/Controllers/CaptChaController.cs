using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using software.common.Common;
using software.common.Model;
using software.common.Service;
using System;
using System.IO;

namespace software.common.Controllers
{
    public class UserEnteredCaptchaCodeModel
    {
        public string UserEnteredCaptchaCode { get; set; }
        public string CaptchaId { get; set; }
    }
    public class CaptChaResult
    {
        public string CaptChaCode { get; set; }
        public byte[] CaptChaByte { get; set; }
        public string CaptChaBase64Data => Convert.ToBase64String(CaptChaByte);
        public DateTime TimeStamp { get; set; }

    }
    [ApiController]
    [Route("[controller]")]
    public class CaptChaController : Controller
    {
        private IMapper _mapper;
        private readonly AppSetting _appsetings;
        public CaptChaController(IMapper mapper,
            IOptions<AppSetting> appsetings,
            IUserService userService)
        {
            _mapper = mapper;
            _appsetings = appsetings.Value;
        }
        [AllowAnonymous]
        [HttpGet("GetCaptChaImage")]
        public ActionResult GetCaptChaImage()
        {
            int width = 100;
            int height = 36;
            var captChaCode = CaptCha.GenerateCaptchaCode();
            var result = CaptCha.GeneratrCaptchaImage(width, height, captChaCode);
            HttpContext.Session.Remove("CaptchaCode");
            HttpContext.Session.SetString("CaptchaCode", result.CaptChaCode);

            Stream s = new MemoryStream(result.CaptChaByte);
            return new FileStreamResult(s, "image/png");
        }
    }
}
