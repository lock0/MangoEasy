using System;
using System.ComponentModel.DataAnnotations;

namespace MangoEasy.Library.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string WebSite { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        /// <summary>
        /// 微信返回的Token
        /// </summary>
        public string AccessToken { get; set; }
        public DateTime? GetAccessTokenDateTime { get; set; }
        public virtual Account Account { get; set; }
    }
}
