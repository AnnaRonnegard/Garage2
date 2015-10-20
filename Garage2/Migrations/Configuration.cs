namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage2.Models;
    using Garage2.DataAccessLayer;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
        context.Vehicles.AddOrUpdate(
                p => p.RegNumber,
            new Vehicle { Type = "Car", RegNumber = "ABC123", Brand = "Volvo", VehicleModel = "V40", Colour = "Red", NumberofWheels = 4 },
            new Vehicle { Type = "Car", RegNumber = "ABC456", Brand = "Volvo", VehicleModel = "V40", Colour = "Red", NumberofWheels = 4 },
            new Vehicle { Type = "Car", RegNumber = "ABC789", Brand = "Volvo", VehicleModel = "V40", Colour = "Green", NumberofWheels = 4 },
            new Vehicle { Type = "Motorcycle", RegNumber = "DEF123", Brand = "Volvo", VehicleModel = "V40", Colour = "Red", NumberofWheels = 2 },
            new Vehicle { Type = "Car", RegNumber = "DEF456", Brand = "Volvo", VehicleModel = "V40", Colour = "Blue", NumberofWheels = 4 }
);
            //
        }
    }
}