using CarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new CarDbContext();
            var carMarks = db.CarMarks.ToList();
            return View(carMarks);
        }

        public ActionResult SpareParts(int id)
        {
            var db = new CarDbContext();
            var carSpareParts = db.CarSpareParts.ToList();
            var spareParts = new List<SparePart>();
            foreach (var item in carSpareParts) {
                if (item.SparePartId == id)
                spareParts.Add(item.SparePart);
            }
            return View(spareParts);
        }
    }
}