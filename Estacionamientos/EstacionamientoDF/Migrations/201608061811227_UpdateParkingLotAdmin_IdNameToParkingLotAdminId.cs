namespace EstacionamientoDF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateParkingLotAdmin_IdNameToParkingLotAdminId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkingLotAreas", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ParkingLots", "Name", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkingLots", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ParkingLotAreas", "Name", c => c.String(nullable: false));
        }
    }
}
