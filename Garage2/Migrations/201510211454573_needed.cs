namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class needed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ParkTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "ParkTime");
        }
    }
}
