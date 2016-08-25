using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeAperture.HDC2016.SampleSite.Controllers
{
    public class ExceptionFilterController : ApiController
    {
        [HttpGet]
        public List<int> GetIdList()
        {
            var valueToAdd = int.Parse("Test");

            return new List<int> { valueToAdd };
        }
    }
}
