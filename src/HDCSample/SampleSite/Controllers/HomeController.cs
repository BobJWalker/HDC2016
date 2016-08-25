using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CodeAperture.HDC2016.SampleSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}