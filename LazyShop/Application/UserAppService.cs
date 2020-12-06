using Domain.User.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class UserAppService : IUserAppService
    {
        public IUserDomainService _userDomainService;
        public UserAppService(IUserDomainService domainService)
        {
            this._userDomainService = domainService;
        }

    }
}
