using Domain.User.Repository.PO;
using Domain.User.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class AuthAppService : IAuthAppService
    {

        public IUserDomainService UserDomainService { get; }

        public AuthAppService(IUserDomainService userDomainService)
        {
            this.UserDomainService = userDomainService;
        }




        /// <summary>
        /// 授权
        /// </summary>
        /// <returns></returns>
        public UserInfo Auth(string username, string password, string vcode)
        {

            return null;
        }
    }
}
