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
            ViewBag.Title = "Content Security Policy";
            return View();
        }

        public ActionResult CookiePolicies()
        {
            ViewBag.Title = "Cookie Policies";
            return View();
        }

        public ActionResult AntiXSSEncoder()
        {
            ViewBag.Title = "Anti XSS Encoder";
            return View();
        }
    }
}