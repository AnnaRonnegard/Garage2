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
        [Display(Name="Reg Number")]
        [Required]                              //Text box cannot be empty
        [StringLength(10, MinimumLength = 3)]     //Maximum Length = 10
        [Key]
        public string RegNumber { get; set; }
        
        [Required]                              //Text box cannot be empty
        [StringLength(10, MinimumLength = 3)]   //Maximum Length = 15, minimum Length = 3    
        
        public string Brand { get; set; }
        [Required]                              //Text box cannot be empty
        [StringLength(12, MinimumLength = 3)]   //Maximum Length = 12, minimum Length = 3
        
        public string Colour { get; set; }
        
        public int VehicleTypeId { get; set; }
        public int MemberId { get; set; }


        [Display(Name = "Park Time")]
        public DateTime ParkTime { get; set; }
        [Display(Name = "Edit Time")]
        public DateTime EditTime { get; set; }


        public virtual VehicleType VehicleType { get; set; } //navigerings-prop 
        public virtual Member Member { get; set; } //navigerings-prop 



    }
}