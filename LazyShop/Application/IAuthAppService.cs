using Domain.User.Repository.PO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IAuthAppService
    {
        UserInfo Auth(string username, string password, string vcode);
    }
}
