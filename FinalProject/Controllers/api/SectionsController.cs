using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;
using FinalProject.Models.Database;

namespace FinalProject.Controllers.api
{
    public class SectionsController : ApiController
    {
        [HttpPost]
        public bool Add(Section section)
        {
            if (validateSection(section))
            {
                SectionDAO.Create(section);
                return true;
            }
            return false;
        }

        private bool validateSection(Section section)
        {
            var valid = true;

            if (string.IsNullOrEmpty(section.CourseName))
            {
                return false;
            }
            foreach (var timeslot in section.Timeslots)
            {
                if (string.IsNullOrEmpty(timeslot.Professor))
                {
                    return false;
                }
                valid = false;
                for (var i = 0; i < 14; i++)
                {
                    
                    if (timeslot.ClassTime[i] != 0)
                    {
                        valid = true;
                    }
                }
            }
            return valid;
        }
    }
}
