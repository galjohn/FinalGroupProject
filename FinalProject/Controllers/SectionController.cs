using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class SectionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            var cookie = Request.Cookies["UserID"]?.Value;
            if (string.IsNullOrEmpty(cookie))
            {
                return RedirectToAction("Login", "Student");
            }
            return View("Section");
        }

        public ActionResult Add()
        {
            var cookie = Request.Cookies["UserID"]?.Value;
            if (string.IsNullOrEmpty(cookie))
            {
                return RedirectToAction("Login", "Student");
            }
            return View("Section");
        }
    }
}