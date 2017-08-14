using System;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Models.ViewModels;

namespace FinalProject.Controllers
{
    public class StudentController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login()
        {
            System.Diagnostics.Debug.WriteLine("Login Page GET request");
            return View();
        }
        [HttpPost]
        public ActionResult Login(Student student)
        {
            if (ModelState.IsValidField("Username") && ModelState.IsValidField("Password"))
            {
                var result = StudentDAO.GetStudent(student.Username, student.Password);
                if (result != null)
                {
                    if (student.Password == result.Password)
                    {
                        Response.SetCookie(new HttpCookie("UserID", result.Username));
                        Response.SetCookie(new HttpCookie("Name", result.FirstName + " " + result.LastName));
                        return RedirectToAction("Home", "Student");
                    }
                }
                ViewBag.NoUser = true;
            }
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            System.Diagnostics.Debug.WriteLine("Register Page GET request");
            return View();
        }
        [HttpPost]
        public ActionResult Register(NewStudentViewModel viewmodel)
        {
            Console.WriteLine("Register Page POST request");
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToAction("Register", "Student");
            }
            //return View("Register", "Student", viewmodel);
            if (StudentDAO.CheckForStudent(viewmodel.Student))
            {
                // username already exists
                return RedirectToAction("Register", "Student");
            }
            if (!StudentDAO.CheckForStudent(viewmodel.Student))
            {
                /*var student = new Student()
                {
                    Username = viewmodel.Username,
                    Password = viewmodel.Password,
                    FirstName = viewmodel.FirstName,
                    LastName = viewmodel.LastName,
                    Program = viewmodel.Program
                };*/
                StudentDAO.Create(viewmodel.Student);
            }
            return RedirectToAction("Login", "Student");
        }
        public ActionResult Logout()
        {
            return Content("Logout Code Needed...");
        }
    }
}