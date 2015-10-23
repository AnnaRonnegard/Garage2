using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.DataAccessLayer;
using Garage2.Models;

namespace Garage2.Controllers
{
    public class VehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        //[HttpGet]
        public ActionResult Search(string searchTerm = null)
        {
            //var model = db.Vehicles.ToList(); //linq-sträng

            var model = db.Vehicles
                .Where(r => searchTerm == null || r.RegNumber.StartsWith(searchTerm))
                .Select (r => r);

            return View(model);
        }

        //public ActionResult Search(string SearchTerm = null)
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
       // public ActionResult Search(string SearchTerm = null)
       ////public ActionResult Search()
       // {
                         
       //     //    vehicle.EditTime = DateTime.Now;
       //     //    db.Vehicles.Add(vehicle);
       //     //    db.SaveChanges();
       //     //    return RedirectToAction("SearchResult");
         
       //    //return View(vehicle);
       //     return View();
       // }






        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegNumber,Brand,VehicleModel,Colour,NumberofWheels")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.ParkTime = DateTime.Now;
                vehicle.EditTime = DateTime.Now;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegNumber,Brand,VehicleModel,Colour,NumberofWheels,ParkTime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.EditTime = DateTime.Now;
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);            
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Receipt", vehicle);
        }

        public ActionResult Receipt(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var TimeNow = DateTime.Now;
            ViewBag.DateTime = TimeNow;
            int ParkDay = TimeNow.Day - vehicle.ParkTime.Day;
            int ParkHour = TimeNow.Hour - vehicle.ParkTime.Hour;
            int ParkMinute = TimeNow.Minute - vehicle.ParkTime.Minute;
            ViewBag.ParkTime = "You have parked " + ParkDay + " days, " + ParkHour + " hours and " + ParkMinute + " minutes";
            return View(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
