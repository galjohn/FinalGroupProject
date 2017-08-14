using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class RestrictionController : Controller
    {
        // GET: Restriction
        public ActionResult Index()
        {
            var cookie = Request.Cookies["UserID"]?.Value;
            if (string.IsNullOrEmpty(cookie))
            {
                return RedirectToAction("Login", "Student");
            }
            return View("Restriction");
        }
        public ActionResult Add()
        {
            var cookie = Request.Cookies["UserID"]?.Value;
            if (string.IsNullOrEmpty(cookie))
            {
                return RedirectToAction("Login", "Student");
            }
            return View("Restriction");
        }
    }
}