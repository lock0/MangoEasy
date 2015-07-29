using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoEasy.Web.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string MediaId { get; set; }
        public Guid FileId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Url { get; set; }
    }
}
