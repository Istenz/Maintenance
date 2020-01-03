namespace MaintenanceService.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maintenance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Car_Brand = c.String(),
                        Car_Model = c.String(),
                        Car_Version = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ReservedDateTime = c.DateTime(nullable: false),
                        MaintenanceId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Maintenance", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Maintenance", new[] { "Customer_Id" });
            DropTable("dbo.Reservation");
            DropTable("dbo.Maintenance");
            DropTable("dbo.Customer");
        }
    }
}
