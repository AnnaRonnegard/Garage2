using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage2.Models
{
    public class VehicleType
    {
        public int Id { get; set; }

        [Display(Name="Type")]
        public string TypeName { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}