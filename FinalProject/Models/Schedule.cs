﻿using System.Collections.Generic;

namespace FinalProject.Models
{
    public class Schedule
    {
        public string StudentId { get; set; }
        public List<Section> Sections { get; set; }
        public string[,] ScheduleMatrix { get; set; }
    }
}