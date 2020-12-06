using Domain.User.Entity.ValueObject;
using Domain.User.SeedWork;
using Infrastructure.Util.GUID;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User.Entity
{
    public class User : IAggregateRoot
    {
		public string Id { get; protected set; }
		public string Mobile { get; set; }
		public string NickName { get; set; }
		public string Email { get; set; }
		public UserSex Sex { get; set; }
		public string HeadImgUrl { get; set; }
		public Address Address { get; set; }
		public UserStatus Status { get; set; }
		public DateTime CreationTime { get; set; }

		public User()
        {
            this.Id = Snowflake.Instance().GetString();
			this.CreationTime = DateTime.Now;
        }

    }
}
