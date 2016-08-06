namespace EstacionamientoDF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnParkingLotAdminIdToParkingLot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkingLots", "ParkingLotAdmin_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ParkingLots", "ParkingLotAdmin_Id");
            AddForeignKey("dbo.ParkingLots", "ParkingLotAdmin_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkingLots", "ParkingLotAdmin_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ParkingLots", new[] { "ParkingLotAdmin_Id" });
            DropColumn("dbo.ParkingLots", "ParkingLotAdmin_Id");
        }
    }
}
