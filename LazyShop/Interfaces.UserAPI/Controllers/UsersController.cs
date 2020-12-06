using Application;
using Interfaces.UserAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.UserAPI.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public IUserAppService UserAppService { get; }

        /// <summary>
        /// 
        /// </summary>
        public UsersController(IUserAppService userAppService)
        {
            this.UserAppService = userAppService;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="userCreateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(UserCreateDTO userCreateDTO)
        {
            
            
            // this.UserAppService.






            return Ok();
        }



    }
}
