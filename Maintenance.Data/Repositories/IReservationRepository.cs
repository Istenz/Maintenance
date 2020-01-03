using MaintenanceService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.Data.Repositories
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
        void Update(Reservation reservation);
        void Remove(Reservation reservation);
        Reservation Get(int id);
        List<Reservation> GetReservations();
    }
}
