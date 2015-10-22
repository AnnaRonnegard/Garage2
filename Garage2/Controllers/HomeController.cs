using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garage2.Models;


namespace Garage2.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private Garage2.DataAccessLayer.GarageContext db = new Garage2.DataAccessLayer.GarageContext();


        public ActionResult Index()
        {

         ViewBag.CountOfVehicle = db.Vehicles.Count();

            // .Select(r => new VehicleModel
            //    {
            //CountOfVehicles = r.
            //    });
                //_db.Restaurants
                //.OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                //.Where(r => searchTerm == null || r.Name.StartsWith(searchTerm)) //filter ej i alt1
                //.Take(10)  //ej i alt1
                //.Select(r => new RetaurantListViewModel
                //    {
                //        Id = r.ID,
                //        Name = r.Name,
                //        City = r.City,
                //        Country = r.Country,
                //        CountOfReviews = r.Reviews.Count()
                //    });



            return View();  //viewbag följer med auto
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}