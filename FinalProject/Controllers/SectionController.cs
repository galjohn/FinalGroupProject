using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class SectionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sections()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
    }
}