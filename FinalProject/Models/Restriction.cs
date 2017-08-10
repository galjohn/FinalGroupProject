using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Restriction
    {
        public Boolean noGapsBiggerThanOneHour { get; set; }
        public Boolean mustHaveOneHourBreaks { get; set; }
        public List<String> noProfessorX { get; set; }
        public List<Timeslot> timeslots { get; set; }
    }
}