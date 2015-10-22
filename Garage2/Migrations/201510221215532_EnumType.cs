namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Type", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
