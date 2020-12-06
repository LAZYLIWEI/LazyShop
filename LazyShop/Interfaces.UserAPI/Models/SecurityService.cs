using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Interfaces.UserAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nickName"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        string CreateToken(string id, string nickName, string mobile);
    }

    /// <summary>
    /// 
    /// </summary>
    public class SecurityService : ISecurityService
    {
        private readonly JwtSetting jwtSetting;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        public SecurityService(IOptions<JwtSetting> option)
        {
            jwtSetting = option.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nickName"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public string CreateToken(string id, string nickName, string mobile)
        {
            //创建用户身份标识，可按需要添加更多信息
            var claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", id, ClaimValueTypes.Integer),
                new Claim("nickName", nickName, ClaimValueTypes.String),
                new Claim("mobile", mobile, ClaimValueTypes.String),
            };

            //创建令牌
            var token = new JwtSecurityToken(
                    issuer: jwtSetting.Issuer,
                    audience: jwtSetting.Audience,
                    signingCredentials: jwtSetting.Credentials,
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddSeconds(jwtSetting.ExpireSeconds));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
