using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.UserAPI.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCreateDTO
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string VCode { get; set; }
    }
}
