using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Garage2.Enum;

namespace Garage2.Models
{
    public class Vehicle
    {
        
        public int Id { get; set; }        
        [Required]                              //Text box cannot be empty
        public Enum.Type Type { get; set; }        //car, plane, motorcycle
        [Display(Name="Reg Number")]
        [Required]                              //Text box cannot be empty
        [StringLength(10)]                      //Maximum Length = 10
        public string RegNumber { get; set; }
        [Required]                              //Text box cannot be empty
        [StringLength(10, MinimumLength = 3)]   //Maximum Length = 15, minimum Length = 3    
        public string Brand { get; set; }
        [Display(Name = "Model")]
        [Required]                              //Text box cannot be empty
        [StringLength(12)]                       //Maximum Length = 10
        public string VehicleModel { get; set; }
        [Required]                              //Text box cannot be empty
        [StringLength(12, MinimumLength = 3)]   //Maximum Length = 12, minimum Length = 3
        public string Colour { get; set; }
        [Display(Name = "Number of Wheels")]
        [Range(0,10)]                           //Range cannot be less then 1 and more then 10
        [Required]                              //Text box cannot be empty
        public int NumberofWheels { get; set; }
        public DateTime ParkTime { get; set; }
        public DateTime EditTime { get; set; }
    }
}