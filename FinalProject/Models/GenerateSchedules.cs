using FinalProject.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace FinalProject.Models
{
    public class GenerateSchedules
    {
        public Restriction Restriction { get; set; }

        public List<Schedule> Schedules { get; set; }

        // TODO: I think its better if we have a studentID as attribute and then call the DAO function to load the sections
        // Either that or just do that before calling the function.
        // So far it returns all possible schedules permutations
        public List<Schedule> GenerateAll(List<Section> sections)
        {

            Schedules = new List<Schedule>();
            int numberOfSchedules = 1;
            int[] sectionCounters = new int[sections.Count];
            int[] sectionCountersMax = new int[sections.Count];
            int sectionsCount = 0;
            // Counts the possible schedules
            // Sets all the section counters to zero
            // Saves the upper limit of the section counters
            foreach (var section in sections)
            {
                numberOfSchedules *= section.Timeslots.Count;
                sectionCounters[sectionsCount] = 0;
                sectionCountersMax[sectionsCount] = section.Timeslots.Count;
                sectionsCount++;
            }


            // Main loop that will run once for each possible schedule
            // Iterates through each possible combination of Sections
            // Adds them to a schedule and adds the schedule to Schedules List
            for (int i = 0; i < numberOfSchedules; i++)
            {
                var sectionSelector = 0;
                var currentSchedule = new Schedule
                {
                    Sections = new List<Section>()
                };
                foreach (var section in sections)
                {
                    currentSchedule.Sections.Add(new Section
                    {
                        CourseName = section.CourseName,
                        Professor = section.Professor,
                        SectionId = section.SectionId,
                        Timeslots = new List<Timeslot>
                        {
                            new Timeslot()
                            {
                                ClassTime = section.Timeslots[sectionCounters[sectionSelector]].ClassTime
                            }
                        }
                    });
                    /*Console.WriteLine(section.CourseName);
                    Console.WriteLine(string.Join(" ", section.Timeslots[sectionCounters[sectionSelector]].ClassTime));*/
                    sectionSelector++;
                }

                Schedules.Add(currentSchedule);

                // Increases the counters in order
                // Increases the last counter, if at max, set it to zero and increases the second to last and so on
                bool countFlag = true;
                int j = sections.Count - 1;
                while (countFlag)
                {

                    if (++sectionCounters[j] >= sectionCountersMax[j])
                    {
                        sectionCounters[j] = 0;
                        j--;
                        if (j < 0)
                        {
                            break;
                        }
                    } else
                    {
                        countFlag = false;
                    }
                }

            }

            return Schedules;


        }

        public bool CheckForOverlap(Schedule schedule)
        {
            return true;
        }

        public bool CheckForNoGaps(Schedule schedule)
        {
            return true;
        }

        public bool CheckForHourGaps(Schedule schedule)
        {
            return true;
        }

        public bool CheckForTeacher(Schedule schedule)
        {
            return true;
        }

        public bool CheckForTimeSlots(Schedule schedule)
        {
            return true;
        }


    }

}