using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User.Repository.PO
{
	/// <summary>
	/// UserLoginInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserLoginInfo
	{
		public UserLoginInfo()
		{ }
		private string _id;
		private string _userid;
		private string _username;
		private string _password;
		private DateTime _creationtime = DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public string Id
		{
			set { _id = value; }
			get { return _id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserId
		{
			set { _userid = value; }
			get { return _userid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Username
		{
			set { _username = value; }
			get { return _username; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set { _password = value; }
			get { return _password; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreationTime
		{
			set { _creationtime = value; }
			get { return _creationtime; }
		}

	}
}


