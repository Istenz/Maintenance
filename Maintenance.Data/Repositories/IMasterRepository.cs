using MaintenanceService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.Data.Repositories
{
    public interface IMasterRepository
    {
        void Create(Master master);
        Master Get(int id);
        List<Master> GetMasters();
    }
}
