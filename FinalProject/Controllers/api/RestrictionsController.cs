using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;

namespace FinalProject.Controllers.api
{
    public class RestrictionsController : ApiController
    {
        [HttpPost]
        public bool Add(Restriction restriction)
        {
            
            return true;
        }
    }
}
