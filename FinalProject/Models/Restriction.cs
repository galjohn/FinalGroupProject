using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Restriction
    {
        public Boolean NoGapsBiggerThanOneHour { get; set; }
        public Boolean MustHaveOneHourBreaks { get; set; }
        public List<String> NoProfessorX { get; set; }
        public List<Timeslot> Timeslots { get; set; }
    }
}