using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage2.Models;

namespace Garage2.DataAccessLayer
{
    public class GarageContext : DbContext
    {
        public GarageContext() : base("DefaultConnection") { }
        public DbSet<Models.Vehicle> Vehicles { get; set; }
        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.VehicleType> VehicleTypes { get; set; }
    }
}