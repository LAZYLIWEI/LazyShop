using Domain.User.Entity.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User.Repository.PO
{
	public partial class UserInfo
	{
		public UserInfo()
		{ }
		private string _id;
		private string _mobile;
		private string _nickname;
		private string _email;
		private int _sex = 0;
		private string _headimgurl;
		private string _address;
		private int _status = 0;
		private DateTime _creationtime = DateTime.Now;
		/// <summary>
		/// id
		/// </summary>
		public string Id
		{
			set { _id = value; }
			get { return _id; }
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string Mobile
		{
			set { _mobile = value; }
			get { return _mobile; }
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string NickName
		{
			set { _nickname = value; }
			get { return _nickname; }
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set { _email = value; }
			get { return _email; }
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int Sex 
		{
			set { _sex = value; }
			get { return _sex; }
		}
		/// <summary>
		/// 头像
		/// </summary>
		public string HeadImgUrl
		{
			set { _headimgurl = value; }
			get { return _headimgurl; }
		}
		/// <summary>
		/// 地址信息
		/// </summary>
		public string Address
		{
			set { _address = value; }
			get { return _address; }
		}
		/// <summary>
		/// 状态0:正常,1,冻结
		/// </summary>
		public int Status
		{
			set { _status = value; }
			get { return _status; }
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreationTime
		{
			set { _creationtime = value; }
			get { return _creationtime; }
		}
	}
}
