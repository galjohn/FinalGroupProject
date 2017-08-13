using System.Collections.Generic;

namespace FinalProject.Models
{
    public class Schedule
    {
        public int StudentId { get; set; }
        public List<Section> Sections { get; set; }
      
    }
}