using MaintenanceService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.Domain.Interfaces
{
    public interface IMaintenanceService
    {
        Maintenance Create(int carId, int customerId, Reservation reservation, int? masterId = null);
    }
}
