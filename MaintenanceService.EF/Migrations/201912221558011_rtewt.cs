namespace MaintenanceService.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rtewt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Maintenance", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Maintenance", new[] { "Customer_Id" });
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Maintenance", "CarId", c => c.Int(nullable: false));
            AddColumn("dbo.Maintenance", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Maintenance", "Car_Brand");
            DropColumn("dbo.Maintenance", "Car_Model");
            DropColumn("dbo.Maintenance", "Car_Version");
            DropColumn("dbo.Maintenance", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Maintenance", "Customer_Id", c => c.Int());
            AddColumn("dbo.Maintenance", "Car_Version", c => c.String());
            AddColumn("dbo.Maintenance", "Car_Model", c => c.String());
            AddColumn("dbo.Maintenance", "Car_Brand", c => c.String());
            DropColumn("dbo.Maintenance", "CustomerId");
            DropColumn("dbo.Maintenance", "CarId");
            DropTable("dbo.Car");
            CreateIndex("dbo.Maintenance", "Customer_Id");
            AddForeignKey("dbo.Maintenance", "Customer_Id", "dbo.Customer", "Id");
        }
    }
}
