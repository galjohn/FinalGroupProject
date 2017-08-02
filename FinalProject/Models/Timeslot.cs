using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Timeslot
    {
        public string dayOfWeek { get; set; }
        public int startTime { get; set; }
        public int duration { get; set; }
    }
}