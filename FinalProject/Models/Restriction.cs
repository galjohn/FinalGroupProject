using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class Restriction
    {
        public Boolean NoGapsBiggerThanOneHour { get; set; }
        public Boolean NoGaps { get; set; }
        public List<String> NoProfessorX { get; set; }
        public List<Timeslot> Timeslots { get; set; }
        public string StudentId { get; set; }
    }
}