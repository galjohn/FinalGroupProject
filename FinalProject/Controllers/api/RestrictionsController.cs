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
    public class RestrictionsController : ApiController
    {
        [HttpPost]
        public string Add(Restriction restriction)
        {
            var dbRestriction = RestrictionDAO.GetRestriction(restriction.StudentId);
            if (dbRestriction == null)
            {
                RestrictionDAO.Create(restriction);
                return "Create";
            }
            RestrictionDAO.Update(restriction);
            return "Update";
        }
    }
}
