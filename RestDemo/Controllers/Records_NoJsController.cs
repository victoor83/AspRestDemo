using BusinessLayer;
using RestDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestDemo.Controllers
{
    public class Records_NoJsController : Controller
    {
        // GET: Records
        public ActionResult Index()
        {
            DataProvider data = new DataProvider();
            Record_NoJs rec = new Record_NoJs
            {
                Id = 101,
                RecordName = "Bouchers",
                RecordDetail = "The basic stocks"
            };
            //ViewBag – ViewBag gets the dynamic view data dictionary. 
            ViewBag.Message = rec;
            return View();
        }
    }
}
