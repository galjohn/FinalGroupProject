using System.Collections.Generic;

namespace FinalProject.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public string CourseName { get; set; }
        public List<Timeslot> Timeslots { get; set; }
    }
}