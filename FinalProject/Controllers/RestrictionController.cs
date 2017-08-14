using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class RestrictionController : Controller
    {
        // GET: Restriction
        public ActionResult Index()
        {
            return View("Restriction");
        }
        public ActionResult Add()
        {
            return View("Restriction");
        }
    }
}