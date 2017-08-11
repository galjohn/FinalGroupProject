using System.Collections.Generic;

namespace FinalProject.Models
{
    public class GenerateSchedules
    {
        public Restriction Restriction { get; set; }
        public List<Section> Sections { get; set; }

        public List<Schedule> Schedules { get; set; }

        
    }

}