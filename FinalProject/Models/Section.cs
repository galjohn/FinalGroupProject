using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public string CourseName { get; set; }
        public Timeslot Timeslot { get; set; }
        public string Professor { get; set; }
    }
}