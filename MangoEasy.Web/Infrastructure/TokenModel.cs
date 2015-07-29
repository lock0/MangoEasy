using System;

namespace MongoDBApi.Web.Infrastructure
{
    public class TokenModel
    {
        public Guid appid { get; set; }
        public string random { get; set; }
        public string signature { get; set; }
    }
   
}