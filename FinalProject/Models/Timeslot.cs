using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Timeslot
    {
        public int DayOfWeek { get; set; }
        public int StartTime { get; set; }
        public int Duration { get; set; }

        /*
        public override string ToString()
        {
            var day = DayOfWeek.ToString();

            var startTime = "";

            if (StartTime < 10)
                startTime = '0' + StartTime.ToString();
            
            startTime += StartTime.ToString();

            var duration = Duration.ToString();

            return day + startTime + duration;
        }

        public static Timeslot ParseTimeslot(string input)
        {
            try
            {
                var parsedTime = new Timeslot();

                parsedTime.DayOfWeek = Int32.Parse(input.Substring(0, 1));
                parsedTime.StartTime = Int32.Parse(input.Substring(1, 2));
                parsedTime.Duration = Int32.Parse(input.Substring(3));
                return parsedTime;
            }
            catch
            {
                return null;
            }  
        }
        */
    }

}