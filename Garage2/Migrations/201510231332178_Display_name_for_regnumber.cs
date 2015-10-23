namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Display_name_for_regnumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "VehicleModel", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "VehicleModel", c => c.String(nullable: false, maxLength: 6));
        }
    }
}
