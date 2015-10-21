using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }  //car, plane, motorcycle
        public string RegNumber { get; set; } 
        public string Brand { get; set; }
        public string VehicleModel { get; set; }
        public string Colour { get; set; }
        public int NumberofWheels { get; set; }
        public DateTime ParkTime { get; set; }
    }
}