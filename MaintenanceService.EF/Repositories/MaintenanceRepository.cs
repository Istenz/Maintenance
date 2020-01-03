using MaintenanceService.Data.Entity;
using MaintenanceService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.EF.Repositories
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        public void Create(Maintenance maintenance)
        {
            using (var context = new MaintenanceContext())
            {
                context.Maintenances.Add(maintenance);
                context.SaveChanges();
            }
        }

        public Maintenance Get(int id)
        {
            using (var context = new MaintenanceContext())
            {
                return context.Maintenances.FirstOrDefault(m => m.Id == id);
            }
        }

        public List<Maintenance> GetMaintenances()
        {
            using (var context = new MaintenanceContext())
            {
                return context.Maintenances.ToList();
            }
        }

        public void Update(Maintenance maintenance)
        {
            using (var context = new MaintenanceContext())
            {
                context.Entry(maintenance).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
