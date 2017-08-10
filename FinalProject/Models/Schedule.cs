using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Schedule
    {
        public int StudentId { get; set; }
        public List<Section> Sections { get; set; }
        public List<Restriction> Restrictions { get; set; }
    }
}