using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class StudentController : Controller
    {

        [HttpPost]
        public ActionResult Login(Student student)
        {
            if (ModelState.IsValidField("Username") && ModelState.IsValidField("Password"))
            {
                var result = StudentDAO.GetStudent(student.Username);
                if (result != null)
                {
                    if (student.Password == result.Password)
                    {
                        Response.SetCookie(new HttpCookie("UserID", result.StudentId.ToString()));
                        Response.SetCookie(new HttpCookie("Name", (result.FirstName.ToString() + " " + result.LastName.ToString())));
                        return RedirectToAction("Index", "Session");
                    }
                }
                ViewBag.NoUser = true;
            }
            return View();
        }
    }
}