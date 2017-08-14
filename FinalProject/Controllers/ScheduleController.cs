using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Models.Database;

namespace FinalProject.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Schedule()
        {
            var cookie = Request.Cookies["UserID"]?.Value;
            if (string.IsNullOrEmpty(cookie))
            {
                return RedirectToAction("Login", "Student");
            }

            var studentSections = SectionDAO.GetStudentSections(int.Parse(cookie));
            if (studentSections == null)
            {
                return RedirectToAction("Index", "Section");
            }
            var studentRestrictions = RestrictionDAO.GetRestriction(int.Parse(cookie));
            if (studentRestrictions == null)
            {
                {
                    return RedirectToAction("Index", "Restriction");
                }
            }

        /*List<Section> dummysections = new List<Section>
        {
            new Section
            {
                SectionId = 1,
                CourseName = "Math 1",
                Timeslots = new List<Timeslot>
                {
                     new Timeslot
                     {
                         ClassTime = new[] {0,0,14,16,0,0,16,18,0,0,0,0,0,0},
                         Professor = "James"
                     },
                    new Timeslot
                    {
                        ClassTime = new[] {0,0,10,16,0,0,0,0,0,0,0,0,0,0},
                        Professor = "Joao"
                    },
                    new Timeslot
                    {
                        ClassTime = new[] {0,0,0,0,16,18,0,0,0,0,0,0,0,0},
                        Professor = "Joao"
                    },
                    new Timeslot
                    {
                        ClassTime = new[] {0,0,0,0,0,0,0,0,11,12,11,20,10,12},
                        Professor = "Joao"
                    },
                },
            },
            new Section
            {
                SectionId = 2,
                CourseName = "Programming 1",
                Timeslots = new List<Timeslot>
                {
                    new Timeslot
                    {
                        ClassTime = new[] {0,0,8,10,0,0,0,0,0,0,0,0,0,0},
                        Professor = "James"
                    },
                    new Timeslot
                    {
                        ClassTime = new[] {0,0,0,0,14,15,0,0,0,0,0,0,0,0},
                        Professor = "James"
                    },
                    new Timeslot
                    {
                        ClassTime = new[] {0,0,0,0,16,17,0,0,0,0,0,0,0,0},
                        Professor = "James"
                    },
                },

            },
            new Section
            {
                SectionId = 3,
                CourseName = "Database 1",
                Timeslots = new List<Timeslot>
                {
                    new Timeslot
                    {
                        ClassTime = new[] {3,4,0,0,0,0,0,0,0,0,0,0,0,0},
                        Professor = "John"
                    },
                    new Timeslot
                    {
                        ClassTime = new[] {5,6,0,0,0,0,0,0,0,0,0,0,0,0},
                        Professor = "John"
                    },
                    new Timeslot
                    {
                        ClassTime = new[] {7,8,0,0,0,0,0,0,0,0,0,0,0,0},
                        Professor = "John"
                    },
                },

            }
        };*/

            /*Restriction restriction = new Restriction
            {
                NoGapsBiggerThanOneHour = false,
                NoGaps = false,
                NoProfessorX = new List<string>() { "Joao", "Pedro" },
                Timeslots = new List<Timeslot>
                {
                    /*new Timeslot
                    {
                        ClassTime = new[] {2,3,0,0,0,0,0,0,0,0,0,0,0,0}
                    },

                    new Timeslot
                    {
                        ClassTime = new[] {7,9,0,0,0,0,0,0,0,0,0,0,0,0}
                    }#1#
                }
            };*/

            GenerateSchedules gs = new GenerateSchedules();

            var schedulesList = gs.GenerateAll(studentSections, studentRestrictions);
            
            return View(schedulesList);
        }
    }
}