using MaintenanceService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.Domain.Interfaces
{
    public interface IReservationService
    {
        bool TimeIsReserved(DateTime time);
        Reservation Reserve(DateTime reservedDateTime);
    }
}
