using MaintenanceService.Data.Entity;
using MaintenanceService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.EF.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        public void Create(Master master)
        {
            using (var context = new MaintenanceContext())
            {
                context.Masters.Add(master);
                context.SaveChanges();
            }
        }

        public Master Get(int id)
        {
            using (var context = new MaintenanceContext())
            {
                return context.Masters.FirstOrDefault(m => m.Id == id);
            }
        }

        public List<Master> GetMasters()
        {
            using (var context = new MaintenanceContext())
            {
                return context.Masters.ToList();
            }
        }
    }
}
