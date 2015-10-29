namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablesvehicletypemembernewseed : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Vehicles");
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        TelephoneNumber = c.String(nullable: false, maxLength: 25),
                        MemberDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vehicles", "VehicleTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "MemberId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Vehicles", "RegNumber");
            DropColumn("dbo.Vehicles", "Id");
            DropColumn("dbo.Vehicles", "Type");
            DropColumn("dbo.Vehicles", "VehicleModel");
            DropColumn("dbo.Vehicles", "NumberofWheels");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "NumberofWheels", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "VehicleModel", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Vehicles", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Vehicles");
            DropColumn("dbo.Vehicles", "MemberId");
            DropColumn("dbo.Vehicles", "VehicleTypeId");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Members");
            AddPrimaryKey("dbo.Vehicles", "Id");
        }
    }
}
