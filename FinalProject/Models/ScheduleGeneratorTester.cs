using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Class to use a main program to test the Schedule Generator Class
// To use create a new project and use this class as the main program
// Import Schedule Generator and all necessary models
namespace FinalProject.Models
{
    public class ScheduleGeneratorTester
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Section> dummysections = new List<Section>
                {
                    new Section
                    {
                        SectionId = 1,
                        CourseName = "Math 1",
                        Timeslots = new List<Timeslot>
                        {
                            /* new Timeslot
                             {
                                 ClassTime = new[] {0,0,14,16,0,0,16,18,0,0,0,0,0,0},
                                 Professor = "James"
                             },*/
                            new Timeslot
                            {
                                ClassTime = new[] {1,2,0,0,0,0,0,0,0,0,0,0,0,0},
                                Professor = "Joao"
                            },
                            new Timeslot
                            {
                                ClassTime = new[] {2,3,0,0,0,0,0,0,0,0,0,0,0,0},
                                Professor = "Joao"
                            },
                            /*new Timeslot
                            {
                                ClassTime = new[] {0,0,0,0,14,16,0,0,12,14,0,0,0,0},
                                Professor = "John"
                            },
                            new Timeslot
                            {
                                ClassTime = new[] {0,0,12,14,0,0,0,0,9,11,0,0,0,0},
                                Professor = "John"
                            },*/
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
                                ClassTime = new[] {2,3,0,0,0,0,0,0,0,0,0,0,0,0},
                                Professor = "James"
                            },
                            new Timeslot
                            {
                                ClassTime = new[] {3,4,0,0,0,0,0,0,0,0,0,0,0,0},
                                Professor = "James"
                            },
                            new Timeslot
                            {
                                ClassTime = new[] {4,5,0,0,0,0,0,0,0,0,0,0,0,0},
                                Professor = "James"
                            },
                            /*new Timeslot
                            {
                                ClassTime = new[] {3,4,0,0,0,0,0,0,0,0,0,0,0,0},
                                Professor = "James"
                            },
                            new Timeslot
                            {
                                ClassTime = new[] {0,0,10,12,0,0,8,12,0,0,0,0,0,0},
                                Professor = "James"
                            },
                            new Timeslot
                            {
                                ClassTime = new[] {0,0,8,12,12,14,0,0,0,0,0,0,0,0},
                                Professor = "Joao"
                            },*/
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
                            /*new Timeslot
                            {
                                ClassTime = new[] {0,0,14,16,0,0,16,18,0,0,0,0,0,0},
                                Professor = "John"
                            },
                            new Timeslot
                            {
                                ClassTime = new[] {4,6,0,0,0,0,0,0,0,0,0,0,0,0},
                                Professor = "John"
                            },
                            new Timeslot
                            {
                                ClassTime = new[] {0,0,0,0,10,12,16,18,0,0,0,0,0,0},
                                Professor = "Joao"
                            },*/
                        },

                    }
                };

                Restriction restriction = new Restriction
                {
                    NoGapsBiggerThanOneHour = false,
                    NoGaps = false,
                    NoProfessorX = new List<string>() { "Joao", "Pedro" },
                    Timeslots = new List<Timeslot>
                    {
                        new Timeslot
                        {
                            ClassTime = new[] {2,3,0,0,0,0,0,0,0,0,0,0,0,0}
                        },

                        new Timeslot
                        {
                            ClassTime = new[] {7,9,0,0,0,0,0,0,0,0,0,0,0,0}
                        }
                    }
                };

                GenerateSchedules gs = new GenerateSchedules();

                var schedulesList = gs.GenerateAll(dummysections, restriction);

                Console.WriteLine($"Possible Schedules: {schedulesList.Count}");

                /*foreach (var section in schedulesList[0].Sections)
                {

                    Console.WriteLine(section.CourseName);
                    Console.WriteLine(string.Join(" ", section.Timeslots[0].ClassTime));
                }*/
                // gs.PrintScheduleMatrix(gs.ScheduleToMatrix(schedulesList[0]));
                int i = 0;
                foreach (var schedule in schedulesList)
                {
                    Console.WriteLine($"Schedule {i}");
                    foreach (var section in schedule.Sections)
                    {

                        Console.WriteLine(section.CourseName);
                        Console.WriteLine(string.Join(" ", section.Timeslots[0].ClassTime));
                    }
                    i++;
                    Console.WriteLine();
                }

                Console.ReadLine();
            }
        }
    }
}