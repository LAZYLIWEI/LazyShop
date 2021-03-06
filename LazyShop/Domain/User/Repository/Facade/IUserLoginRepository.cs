﻿using Domain.User.Entity;
using Domain.User.Repository.PO;
using Domain.User.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User.Repository.Facade
{
    public interface IUserLoginRepository : IBaseRepository<UserLoginInfo>
    {

    }
}
