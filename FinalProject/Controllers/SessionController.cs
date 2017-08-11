using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Sessions()
        {
            return View();
        }
    }
}