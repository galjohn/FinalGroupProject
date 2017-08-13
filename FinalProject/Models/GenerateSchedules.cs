using FinalProject.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace FinalProject.Models
{
    public class GenerateSchedules
    {
        public List<Schedule> Schedules { get; set; }

        public List<Schedule> GenerateAll(List<Section> sections, Restriction restriction)
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
                        SectionId = section.SectionId,
                        Timeslots = new List<Timeslot>
                        {
                            new Timeslot()
                            {
                                ClassTime = section.Timeslots[sectionCounters[sectionSelector]].ClassTime,
                                Professor = section.Timeslots[sectionCounters[sectionSelector]].Professor
                            }
                        }
                    });
                    /*Console.WriteLine(section.CourseName);
                    Console.WriteLine(string.Join(" ", section.Timeslots[sectionCounters[sectionSelector]].ClassTime));*/
                    sectionSelector++;
                }
                if (CheckForRestrictions(currentSchedule, restriction))
                {
                    Schedules.Add(currentSchedule);
                }


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

        private bool CheckForRestrictions(Schedule schedule, Restriction restricion)
        {
            if (!CheckForOverlap(schedule))
            {
                return false;
            }

            if (restricion.NoGapsBiggerThanOneHour)
            {
                if (!CheckForNoGaps(schedule))
                {
                    return false;
                }
            }

            if (restricion.MustHaveOneHourBreaks)
            {
                if (!CheckForHourGaps(schedule))
                {
                    return false;
                }
            }

            if (restricion.NoProfessorX.Count > 0)
            {
                foreach (var teacher in restricion.NoProfessorX)
                {
                    if (!CheckForTeacher(schedule, teacher))
                    {
                        return false;
                    }
                }
            }

            if (restricion.Timeslots.Count > 0)
            {
                for (int i = 0; i < restricion.Timeslots.Count - 1; i++)
                {
                    if (!CheckForTimeSlots(schedule, restricion.Timeslots[i].ClassTime))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckForOverlap(Schedule schedule)
        {
            // Loops through each section, keeping count
            int sectionNumber = 0;
            foreach (var baseSection in schedule.Sections)
            {
                // Schedule's sections only have one timeslot
                var baseClassTime = baseSection.Timeslots[0].ClassTime;
                // Loops through the remaining sections, starting with the following section
                for (int i = sectionNumber + 1; i < schedule.Sections.Count; i++)
                {
                    // Gets the Classtime from the next section
                    var toCompareClassTime = schedule.Sections[i].Timeslots[0].ClassTime;

                    // Loops through each day
                    for (int j = 0; j < 6; j++)
                    {
                        // If either section has no class in the day, no need to compare for overlap
                        if (baseClassTime[j] != 0 || toCompareClassTime[j] != 0)
                        {
                            // If the starting time to be checked is between start and end time of current section OR
                            // the ending time is between start and end time of current section
                            // return false
                            if ((toCompareClassTime[j] >= baseClassTime[j] &&
                                 toCompareClassTime[j] < baseClassTime[j + 1]) ||
                                (toCompareClassTime[j + 1] > baseClassTime[j] &&
                                 toCompareClassTime[j + 1] <= baseClassTime[j + 1]))
                            {
                                return false;
                            }
                        }
                    }
                }
                sectionNumber++;
            }
            // If the schedule gets here, means no overlap ocurred
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

        public bool CheckForTeacher(Schedule schedule, string teacher)
        {
            return true;
        }

        public bool CheckForTimeSlots(Schedule schedule, int[] classtime)
        {
            return true;
        }


    }

}