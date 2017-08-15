using System.Collections.Generic;
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
            // To load some section data, uncomment this block and do this ONCE (Comment after doing it):
            // Run the app, log in and select view schedule. Stop the program.
            // Change the student id to whatever student id you want to use
            /*
            List<Section> dummySections = new List<Section>
                        {
                            new Section
                            {
                                SectionId = 1,
                                CourseName = "Math",
                                Timeslots = new List<Timeslot>
                                {
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,8,11,0,0,8,11,0,0,0,0,0,0},
                                        Professor = "John"
                                    },
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,0,0,8,11,8,11,0,0,0,0},
                                        Professor = "James"
                                    },
                                },
                            },
                            new Section
                            {
                                SectionId = 2,
                                CourseName = "Programming",
                                Timeslots = new List<Timeslot>
                                {
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,11,14,0,0,0,0,11,14,0,0,0,0},
                                        Professor = "Bill"
                                    },
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,12,15,0,0,0,0,11,14,0,0,0,0},
                                        Professor = "Bob"
                                    },
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,12,15,0,0,11,14,0,0,0,0},
                                        Professor = "Buck"
                                    },
                                },
                            },
                            new Section
                            {
                                SectionId = 3,
                                CourseName = "Database",
                                Timeslots = new List<Timeslot>
                                {
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,15,18,0,0,0,0,0,0,14,17,0,0},
                                        Professor = "Cole"
                                    },
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,15,18,11,14,0,0,0,0,0,0,0,0},
                                        Professor = "Cid"
                                    },
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,11,14,11,14,0,0,0,0,0,0},
                                        Professor = "Cid"
                                    },
                                },
                            },
                            new Section
                            {
                                SectionId = 4,
                                CourseName = "Business",
                                Timeslots = new List<Timeslot>
                                {
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,0,0,0,0,0,0,11,14,0,0},
                                        Professor = "Daniel"
                                    },
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,0,0,0,0,0,0,12,15,0,0},
                                        Professor = "Dante"
                                    },
                                },
                            },
                            new Section
                            {
                                SectionId = 5,
                                CourseName = "Logic",
                                Timeslots = new List<Timeslot>
                                {
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,0,0,0,0,0,0,8,11,0,0},
                                        Professor = "Emir"
                                    },
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,0,0,8,11,0,0,0,0,0,0},
                                        Professor = "Elton"
                                    },
                                },
                            },
                            new Section
                            {
                                SectionId = 6,
                                CourseName = "Elective",
                                Timeslots = new List<Timeslot>
                                {
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,8,11,0,0,0,0,0,0,0,0},
                                        Professor = "Emir"
                                    },
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,0,0,11,14,0,0,0,0,0,0},
                                        Professor = "Emir"
                                    },
                                    new Timeslot
                                    {
                                        ClassTime = new[] {0,0,0,0,0,0,0,0,8,11,0,0,0,0},
                                        Professor = "Elton"
                                    },
                                },
                            },
                        };

            foreach (var dummySection in dummySections)
            {
                SectionDAO.Create(dummySection);

            Restriction dummyRestriction = new Restriction
            {
                StudentId = "jpedro",
                NoGapsBiggerThanOneHour = false,
                NoGaps = false,
                NoProfessorX = new List<string>() { "John", "Elton" },
                Timeslots = new List<Timeslot>
                            {
                                new Timeslot
                                {
                                    ClassTime = new[] {0,0,0,0,8,20,0,0,0,0,0,0,0,0}
                                },
            
                                /*
                                new Timeslot
                                {
                                    ClassTime = new[] {7,9,0,0,0,0,0,0,0,0,0,0,0,0}
                                }#1#
                            }
            };

            RestrictionDAO.Create(dummyRestriction);
            */
            var cookie = Request.Cookies["UserID"]?.Value;
            if (string.IsNullOrEmpty(cookie))
            {
                return RedirectToAction("Login", "Student");
            }

            var studentSections = SectionDAO.GetSections();
            if (studentSections == null)
            {
                return RedirectToAction("Index", "Section");
            }
            var studentRestrictions = RestrictionDAO.GetRestriction(cookie);
            if (studentRestrictions == null)
            {
                {
                    return RedirectToAction("Index", "Restriction");
                }
            }
            GenerateSchedules gs = new GenerateSchedules();

            var schedulesList = gs.GenerateAll(studentSections, studentRestrictions);
            
            return View(schedulesList);
        }
    }
}