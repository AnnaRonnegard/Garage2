namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Type", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Vehicles", "Type", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
