using System;
using System.Collections.Generic;

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

            if (restricion.NoGaps)
            {
                if (!CheckForNoGaps(schedule))
                {
                    return false;
                }
            }

            if (restricion.NoGapsBiggerThanOneHour)
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
                foreach (Timeslot t in restricion.Timeslots)
                {
                    if (!CheckForTimeSlots(schedule, t.ClassTime))
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
                        if (baseClassTime[j * 2] != 0 || toCompareClassTime[j * 2] != 0)
                        {
                            // If the starting time to be checked is between start and end time of current section OR
                            // the ending time is between start and end time of current section
                            // return false
                            if ((toCompareClassTime[j * 2] >= baseClassTime[j * 2] &&
                                 toCompareClassTime[j * 2] < baseClassTime[j * 2 + 1]) ||
                                (toCompareClassTime[j * 2 + 1] > baseClassTime[j * 2] &&
                                 toCompareClassTime[j * 2 + 1] <= baseClassTime[j * 2 + 1]))
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
            bool[,] scheduleMatrix = ScheduleToMatrix(schedule);
            // Loop through each day
            for (int i = 0; i < scheduleMatrix.GetLength(0); i++)
            {
                bool atLeastOneClass = false;
                // Loop Through each hour
                for (int j = 0; j < scheduleMatrix.GetLength(1); j++)
                {
                    // If true, there is a class at this time
                    // Flags that theres at least one class
                    if (scheduleMatrix[i, j] && !atLeastOneClass)
                    {
                        atLeastOneClass = true;
                    }
                    // Whenever there is an empty hour will check for more classes
                    // If any found, means there is a gap in the schedule
                    if (!scheduleMatrix[i, j] && atLeastOneClass)
                    {
                        for (int k = j + 1; k < scheduleMatrix.GetLength(1); k++)
                        {
                            if (scheduleMatrix[i, k])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool CheckForHourGaps(Schedule schedule)
        {

            bool[,] scheduleMatrix = ScheduleToMatrix(schedule);
            int gapTime = 0;
            // Loop through each day
            for (int i = 0; i < scheduleMatrix.GetLength(0); i++)
            {
                bool classPresent = false;
                // Loop Through each hour
                for (int j = 0; j < scheduleMatrix.GetLength(1); j++)
                {
                    // If true, there is a class at this time
                    // Flags that theres a class
                    // Zeroes gap counter
                    if (scheduleMatrix[i, j] && !classPresent)
                    {
                        classPresent = true;
                        gapTime = 0;
                    }
                    // Whenever there is an empty hour will check for more classes
                    // If any found, means there is a gap in the schedule
                    // Will count the gap and discard schedule if larger than 1 hour
                    if (!scheduleMatrix[i, j] && classPresent)
                    {
                        for (int k = j + 1; k < scheduleMatrix.GetLength(1); k++)
                        {
                            gapTime++;
                            if (scheduleMatrix[i, k])
                            {
                                if (gapTime > 1)
                                {
                                    return false;
                                }
                                gapTime = 0;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool CheckForTeacher(Schedule schedule, string teacher)
        {
            return true;
        }

        public bool CheckForTimeSlots(Schedule schedule, int[] classtime)
        {
            bool[,] scheduleMatrix = ScheduleToMatrix(schedule);
            foreach (var section in schedule.Sections)
            {
                // Day
                for (int i = 0; i < 6; i++)
                {
                    // If there is no restriction, skip this
                    if (classtime[i * 2] != 0 || classtime[i * 2 + 1] != 0)
                    {
                        // Hour
                        for (int j = classtime[i * 2] - 1; j < classtime[i * 2 + 1] - 1; j++)
                        {
                            if (scheduleMatrix[i, j])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool[,] ScheduleToMatrix(Schedule schedule)
        {
            bool[,] scheduleMatrix = new bool[7, 24];
            foreach (var section in schedule.Sections)
            {
                // Day
                for (int i = 0; i < 6; i++)
                {

                    if (section.Timeslots[0].ClassTime[i * 2] != 0)
                    {
                        for (int j = section.Timeslots[0].ClassTime[i * 2] - 1; j < section.Timeslots[0].ClassTime[(i * 2) + 1] - 1; j++)
                        {
                            scheduleMatrix[i, j] = true;
                        }
                    }
                }
            }
            return scheduleMatrix;
        }


        // Function for debugging, delete for "production"
        public void PrintScheduleMatrix(bool[,] scheduleMatrix)
        {
            Console.WriteLine("Schedule:");
            Console.WriteLine("      sun   mon   tue   wed   thu   fri   sat ");
            int rowLength = scheduleMatrix.GetLength(1);
            int colLength = scheduleMatrix.GetLength(0);

            for (int i = 0; i < rowLength; i++)
            {
                if (i < 9)
                {
                    Console.Write(0);
                }
                Console.Write(i + 1 + "h ");
                for (int j = 0; j < colLength; j++)
                {

                    Console.Write(scheduleMatrix[j, i] + " ");
                    if (scheduleMatrix[j, i])
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

}