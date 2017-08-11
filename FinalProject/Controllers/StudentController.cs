using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Models.ViewModels;

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
                        return RedirectToAction("Index", "Section");
                    }
                }
                ViewBag.NoUser = true;
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            System.Diagnostics.Debug.WriteLine("Signup Page GET request");
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student student, NewStudentViewModel viewmodel)
        {
            Console.WriteLine("Signup Page POST request");
            if (!ModelState.IsValid)
                return RedirectToAction("Register", "Student");
            //return View("Register", "Student", viewmodel);
            if (StudentDAO.CheckForStudent(student))
            {
                // username already exists
                return RedirectToAction("Register", "Student");
            }
            if (!StudentDAO.CheckForStudent(student))
            {
                StudentDAO.Create(student);
            }
            return RedirectToAction("Login", "Student");
        }
        public ActionResult Logout()
        {
            return Content("Logout Code Needed...");
        }
    }
}