using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestDemo.Controllers
{
    public class PlaygroundController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
    }
}