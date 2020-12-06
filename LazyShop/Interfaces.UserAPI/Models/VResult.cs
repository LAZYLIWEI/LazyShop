using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.UserAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class VResult
    {
        /// <summary>
        /// 返回值
        /// </summary>
        [JsonProperty("code")]
        public ReturnCode Code { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        /// <summary>
        /// 扩展数据
        /// </summary>
        [JsonProperty("extend")]
        public object extend { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public enum ReturnCode
    {
        /// <summary>
        /// 
        /// </summary>
        FAIL = 100,
        /// <summary>
        /// 
        /// </summary>
        SUCCESS = 200,
        /// <summary>
        /// 
        /// </summary>
        EXCEPTION = 500,
    }


}
