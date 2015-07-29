using System.Web.Mvc;

namespace MangoEasy.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Demo()
        {
            ViewBag.Message = "Demo";

            return View();
        }
        public ActionResult ScanCodeLogin()
        {
            ViewBag.Message = "ScanCodeLogin";
            var url =
                "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx990c1d301ce34a46&redirect_uri=http%3a%2f%2fhersheys.mangoeasy.com&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";

            return Redirect(url);
        }
    }
}