using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class SectionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            return View("Section");
        }

        public ActionResult Sections()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View("Section");
        }
    }
}