using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAperture.HDC2016.SampleSite.Controllers
{
    public class ConfigurationChangesController : Controller
    {
        // GET: 
        public ActionResult ContentSecurityPolicy()
        {
            return View();
        }

        public ActionResult CookiePolicies()
        {
            return View();
        }
    }
}