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

            context.VehicleTypes.AddOrUpdate (
                v => v.Id,
                new VehicleType {TypeName="Car" },
                new VehicleType {TypeName="MotorCycle" },
                new VehicleType {TypeName="Bicycle" }
                );
            context.SaveChanges();
            context.Members.AddOrUpdate(
                m => m.Id,
                new Member { FirstName="Olle", LastName="Scott", TelephoneNumber="074-1234567",MemberDate=DateTime.Now},
                new Member { FirstName="AnnaKarin", LastName="Rönnegård", TelephoneNumber="073-0755356",MemberDate=DateTime.Now},
                new Member { FirstName="Olga", LastName="Kagyrina", TelephoneNumber="072-2016667",MemberDate=DateTime.Now},
                new Member { FirstName="Christina", LastName="Kronblad", TelephoneNumber="08-4647515",MemberDate=DateTime.Now}
                );


//        context.Vehicles.AddOrUpdate(
//                p => p.RegNumber,
//            new Vehicle { VehicleTypeId = 1, RegNumber = "ABC123", Brand = "Volvo", Colour = "Red", ParkTime = DateTime.Now, EditTime = DateTime.Now},
//            new Vehicle { VehicleTypeId = 1, RegNumber = "ABC456", Brand = "Volvo", Colour = "Red", ParkTime = DateTime.Now, EditTime = DateTime.Now },
//            new Vehicle { VehicleTypeId = 1, RegNumber = "ABC789", Brand = "Volvo", Colour = "Green", ParkTime = DateTime.Now, EditTime = DateTime.Now },
//            new Vehicle { VehicleTypeId = 2, RegNumber = "DEF123", Brand = "Volvo", Colour = "Red", ParkTime = DateTime.Now, EditTime = DateTime.Now },
//            new Vehicle { VehicleTypeId = 1, RegNumber = "DEF456", Brand = "Volvo", Colour = "Blue", ParkTime = DateTime.Now, EditTime = DateTime.Now }
//);
            //
            context.SaveChanges();
        }
    }
}
