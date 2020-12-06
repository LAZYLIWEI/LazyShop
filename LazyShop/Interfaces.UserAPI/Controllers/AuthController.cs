using Application;
using Interfaces.UserAPI.DTO;
using Interfaces.UserAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.UserAPI.Controllers
{
    /// <summary>
    /// 授权
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public IAuthAppService AuthAppService { get; }

        /// <summary>
        /// 
        /// </summary>
        public ISecurityService SecurityService { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authAppService"></param>
        public AuthController(IAuthAppService authAppService)
        {
            this.AuthAppService = authAppService;
        }

        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="authDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Auth(AuthDTO authDTO)
        {
            VResult result = new VResult() { 
                Code = ReturnCode.FAIL
            };
            if (!ModelState.IsValid)
            {
                result.Msg = "参数有误";
                return new JsonResult(result);
            }
            var userInfo = this.AuthAppService.Auth(authDTO.Username, authDTO.Password, authDTO.VCode);
            if (userInfo != null)
            {
                result.Code = ReturnCode.SUCCESS;
                result.Data = this.SecurityService.CreateToken(userInfo.Id, userInfo.NickName, userInfo.Mobile);
                result.Msg = "授权成功";
            }
            else
            {
                result.Msg = "授权失败";
            }

            return new JsonResult(result);
        }

    }
}
