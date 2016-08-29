using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAperture.HDC2016.SampleSite.Controllers
{
    public class FilterController : Controller
    {
        public ActionResult GlobalExceptionHandling()
        {
            ViewBag.Title = "Global Exception Handling - WebApi";
            return View();
        }

        public ActionResult ActionFilter()
        {
            ViewBag.Title = "Action Filter - WebApi";
            return View();
        }
    }
}