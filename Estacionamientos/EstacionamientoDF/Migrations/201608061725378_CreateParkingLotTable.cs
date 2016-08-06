namespace EstacionamientoDF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateParkingLotTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkingLotAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Slots = c.Int(nullable: false),
                        UsedSlots = c.Int(nullable: false),
                        ParkingLotId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParkingLots", t => t.ParkingLotId, cascadeDelete: true)
                .Index(t => t.ParkingLotId);
            
            CreateTable(
                "dbo.ParkingLots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ParkingLotAdmin_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ParkingLotAdmin_Id)
                .Index(t => t.ParkingLotAdmin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkingLotAreas", "ParkingLotId", "dbo.ParkingLots");
            DropForeignKey("dbo.ParkingLots", "ParkingLotAdmin_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ParkingLots", new[] { "ParkingLotAdmin_Id" });
            DropIndex("dbo.ParkingLotAreas", new[] { "ParkingLotId" });
            DropTable("dbo.ParkingLots");
            DropTable("dbo.ParkingLotAreas");
        }
    }
}
