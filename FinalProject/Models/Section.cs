using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Section
    {
        public int sectionID { get; set; }
        public string courseName { get; set; }
        public Timeslot timeslot { get; set; }
        public string professor { get; set; }
    }
}