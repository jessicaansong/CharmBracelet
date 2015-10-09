using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charm.Controllers
{
    public class AboutController : Controller  //controller is the base class 
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
    }
}