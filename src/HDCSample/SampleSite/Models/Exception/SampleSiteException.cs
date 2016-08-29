using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeAperture.HDC2016.SampleSite.Models.Exception
{
    public class SampleSiteException : System.Exception
    {
        public SampleSiteException(string message) : base(message)
        {            
        }
    }
}