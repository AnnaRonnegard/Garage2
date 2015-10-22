namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Type", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Vehicles", "Brand", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Vehicles", "VehicleModel", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Vehicles", "Colour", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Colour", c => c.String());
            AlterColumn("dbo.Vehicles", "VehicleModel", c => c.String());
            AlterColumn("dbo.Vehicles", "Brand", c => c.String());
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.String());
            AlterColumn("dbo.Vehicles", "Type", c => c.String());
        }
    }
}
