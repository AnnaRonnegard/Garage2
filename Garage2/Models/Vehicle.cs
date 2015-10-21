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
        [Required]                              //Text box cannot be empty
        [StringLength(15, MinimumLength = 3)]   //Maximum Length = 15, minimum Length = 3   
        public string Type { get; set; }        //car, plane, motorcycle
        [Required]                              //Text box cannot be empty
        [StringLength(10)]                      //Maximum Length = 10
        public string RegNumber { get; set; }
        [Required]                              //Text box cannot be empty
        [StringLength(10, MinimumLength = 3)]   //Maximum Length = 15, minimum Length = 3    
        public string Brand { get; set; }
        [Required]                              //Text box cannot be empty
        [StringLength(6)]                       //Maximum Length = 10
        public string VehicleModel { get; set; }
        [Required]                              //Text box cannot be empty
        [StringLength(12, MinimumLength = 3)]   //Maximum Length = 12, minimum Length = 3
        public string Colour { get; set; }
        [Range(2,10)]                           //Range cannot be less then 1 and more then 10
        [Required]                              //Text box cannot be empty
        public int NumberofWheels { get; set; }

    }
}