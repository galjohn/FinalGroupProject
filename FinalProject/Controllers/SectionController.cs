using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

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