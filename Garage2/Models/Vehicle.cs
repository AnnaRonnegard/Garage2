using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Garage2.Models
{
    public class Vehicle
    {
        
        public int Id { get; set; }        
        [Required]
        [StringLength(15, MinimumLength = 3)]      
        public string Type { get; set; }  //car, plane, motorcycle
        [Required]
        [StringLength(10)]
        public string RegNumber { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3)]       
        public string Brand { get; set; }
        [Required]
        [StringLength(6)]      
        public string VehicleModel { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 3)]     
        public string Colour { get; set; }
        [Range(2,10)]
        [Required]
        public int NumberofWheels { get; set; }

    }
}