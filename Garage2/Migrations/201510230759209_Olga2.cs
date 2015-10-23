namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olga2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "DeleteTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "DeleteTime", c => c.DateTime(nullable: false));
        }
    }
}
