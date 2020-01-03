namespace MaintenanceService.EF.Migrations
{
    using MaintenanceService.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MaintenanceService.EF.MaintenanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MaintenanceService.EF.MaintenanceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var BMWMaster = new Master { Id = 1, Name = "Gena", Surname = "Bukin", CarBrand = "BMW" };
            var AudiMaster = new Master { Id = 2, Name = "Sasha", Surname = "Petrenko", CarBrand = "Audi" };

            context.Masters.AddOrUpdate(BMWMaster, AudiMaster);

        }
    }
}
