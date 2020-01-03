using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceService.Data.Entity;

namespace MaintenanceService.Data.Repositories
{
    public interface IMaintenanceRepository
    {
        void Create(Maintenance maintenance);
        void Update(Maintenance maintenance);
        Maintenance Get(int id);
        List<Maintenance> GetMaintenances();
    }
}
