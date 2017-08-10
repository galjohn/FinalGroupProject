using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Timeslot
    {
        public string DayOfWeek { get; set; }
        public int StartTime { get; set; }
        public int Duration { get; set; }
    }
}