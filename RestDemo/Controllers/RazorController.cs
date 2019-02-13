using BusinessLayer;
using RestDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestDemo.Controllers
{
    public class RazorController : Controller
    {
        public ActionResult Index()
        {
            DataProvider data = new DataProvider();
            PersonDto person = data.GetAllPersons()[0];

            //ViewBag – ViewBag gets the dynamic view data dictionary. 
            ViewBag.Message = person;
            return View();
        }
    }
}
