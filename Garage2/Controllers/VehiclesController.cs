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
 //           Vehicle vehicle = db.Vehicles.Find(id);

            ViewBag.FullName = "Member";
            ViewBag.Empty = "";
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



        //[HttpGet]
        public ActionResult Search(string searchTerm = null)
        {
            //var model = db.Vehicles.ToList(); //linq

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

        public ActionResult Create()
        {
            
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Id");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "TypeName");

            return View();
        }

        // POST: Vehicles2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegNumber,Brand,Colour,VehicleTypeId,MemberId")] Vehicle vehicle)
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
            int totalMinutes = ParkDay*24*60+ParkHour*60+ParkMinute;
            int ParkNoDays = Convert.ToInt32(totalMinutes/(24*60));
            int RestMinutes = totalMinutes - ParkNoDays * 24 * 60;
            int ParkNoHours = Convert.ToInt32(RestMinutes/60);
            int ParkNoMinutes = RestMinutes - ParkNoHours * 60;

            ViewBag.ParkTime = "Du har parkerat " + ParkNoDays + " days, " + 
                ParkNoHours + " hours and " + ParkNoMinutes + " minutes";
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
