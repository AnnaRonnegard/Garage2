namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class icoollectioninmodelsmemberandvehicletype : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Vehicles", "VehicleTypeId");
            CreateIndex("dbo.Vehicles", "MemberId");
            AddForeignKey("dbo.Vehicles", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "MemberId", "dbo.Members");
            DropIndex("dbo.Vehicles", new[] { "MemberId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
        }
    }
}
