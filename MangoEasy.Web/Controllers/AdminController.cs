using System.Web.Mvc;

namespace MangoEasy.Web.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Message = "Admin";
            return View();
        }
    }
}