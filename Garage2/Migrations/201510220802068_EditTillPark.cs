namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTillPark : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "EditTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "EditTime", c => c.DateTime(nullable: false));
        }
    }
}
