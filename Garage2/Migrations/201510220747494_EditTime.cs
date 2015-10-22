namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "EditTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "EditTime");
        }
    }
}
