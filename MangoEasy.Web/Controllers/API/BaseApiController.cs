using System.Web.Http;
using System.Web.Http.Cors;

namespace MangoEasy.Web.Controllers.API
{
   
    public class BaseApiController : ApiController
    {
        protected ResponseModel Success()
        {
            return new ResponseModel
            {
                ErrorCode = 0,
                Message = "success",
                Error = false
            };
        }
        protected ResponseModel Failed(string message)
        {
            return new ResponseModel
            {
                ErrorCode = 0,
                Message = message,
                Error = true
            };
        }
    }
    public class ResponseModel
    {
        public int Id { get; set; }
        public int ErrorCode { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public string DebugMessage { get; set; }
    }
}