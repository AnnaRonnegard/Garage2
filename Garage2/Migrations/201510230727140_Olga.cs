namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olga : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "DeleteTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "DeleteTime");
        }
    }
}
