using CarApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarApp.Controllers
{
    public class CreateController : Controller
    {
        EditModel e = new EditModel();
        public ActionResult Index()
        {
            var db = new CarDbContext();
            var carMarks = db.CarMarks.ToList();
            e.CarMarks = carMarks;
            e.CarMarks = new List<CarMark>();
            e.CarMarks.AddRange(GetCarMarks());
            e.SpareParts = new List<SparePart>();
            e.SpareParts.AddRange(GetSpareParts());
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCarMark(EditModel e)
        {
            if (!ModelState.IsValid) return View("Index", e);
            var c = new CarMark()
            {
                Name = e.CarMark.Name
            };
            SaveCarMark(c);
            return RedirectToAction("Index");
        }

        public CarMark SaveCarMark(CarMark c)
        {
            CarDbContext db = new CarDbContext();
            db.CarMarks.Add(c);
            db.SaveChanges();
            return c;
        }

        public List<CarMark> GetCarMarks()
        {
            CarDbContext db = new CarDbContext();
            return db.CarMarks.ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSparePart(EditModel e)
        {
            if (!ModelState.IsValid) return View("Index", e);
            var s = new SparePart
            {
                Name = e.SparePart.Name,
                Code = e.SparePart.Code
            };
            SaveSparePart(s);
            return RedirectToAction("Index");
        }

        public SparePart SaveSparePart(SparePart s)
        {
            CarDbContext db = new CarDbContext();
            db.SpareParts.Add(s);
            db.SaveChanges();
            return s;
        }
        public List<SparePart> GetSpareParts()
        {
            CarDbContext db = new CarDbContext();
            return db.SpareParts.ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCarSparePart(EditModel e)
        {
            if (!ModelState.IsValid) return View("Index", e);
            var cs = new CarSparePart
            {
                CarMarkId = e.SelectedCarMarkId,
                SparePartId = e.SelectedSparePartId
            };
            SaveCarSparePart(cs);
            return RedirectToAction("Index");
        }

        public CarSparePart SaveCarSparePart(CarSparePart cs)
        {
            CarDbContext db = new CarDbContext();
            db.CarSpareParts.Add(cs);
            db.SaveChanges();
            return cs;
        }

        public List<CarSparePart> GetCarSpareParts()
        {
            CarDbContext db = new CarDbContext();
            return db.CarSpareParts.ToList();
        }
        
        public ActionResult Delete(int id)
        {
            CarDbContext db = new CarDbContext();
            var c = db.CarMarks.FirstOrDefault(x => x.Id == id);
            db.CarMarks.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}