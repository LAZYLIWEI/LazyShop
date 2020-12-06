using Domain.User.Entity.ValueObject;
using Domain.User.Repository.PO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User.Service
{
    public class UserFactory : IUserFactory
    {

        public Entity.User CreateUser(UserInfo userInfo)
        {
            Entity.User user = new Entity.User
            {
                Email = userInfo.Email,
                Address = JsonConvert.DeserializeObject<Address>(userInfo.Address),
                Status = (UserStatus)userInfo.Status,
                CreationTime = userInfo.CreationTime,
                HeadImgUrl = userInfo.HeadImgUrl,
                Mobile = userInfo.Mobile,
                NickName = userInfo.NickName,
                Sex = (UserSex)userInfo.Sex
            };

            return user;
        }


        public UserInfo CreateUserPO(Entity.User user)
        {
            UserInfo userInfo = new UserInfo
            {
                Id = user.Id,
                Mobile = user.Mobile,
                NickName = user.NickName,
                Sex = Convert.ToInt32(user.Sex),
                Status = Convert.ToInt32(user.Status),
                HeadImgUrl = user.HeadImgUrl,
                CreationTime = user.CreationTime,
                Address = JsonConvert.SerializeObject(user.Address),
                Email = user.Email
            };
            return userInfo;
        }


    }
}
