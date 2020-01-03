using MaintenanceService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.EF
{
    class MaintenanceContext : DbContext
    {
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Master> Masters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Master>();

            modelBuilder.Entity<Maintenance>();

            modelBuilder.Entity<Customer>();

            modelBuilder.Entity<Car>();

            modelBuilder.Entity<Reservation>();
        }
    }
}
