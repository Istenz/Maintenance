namespace MaintenanceService.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Master",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        CarBrand = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Maintenance", "MasterId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Maintenance", "MasterId");
            DropTable("dbo.Master");
        }
    }
}
