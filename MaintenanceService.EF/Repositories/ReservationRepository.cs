using MaintenanceService.Data.Entity;
using MaintenanceService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.EF.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public void Create(Reservation reservation)
        {
            using (var context = new MaintenanceContext())
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }
        }

        public Reservation Get(int id)
        {
            using (var context = new MaintenanceContext())
            {
                return context.Reservations
                    .FirstOrDefault(r => r.Id == id);
            }
        }

        public List<Reservation> GetReservations()
        {
            using (var context = new MaintenanceContext())
            {
                return context.Reservations.ToList();
            }
        }

        public void Remove(Reservation reservation)
        {
            using (var context = new MaintenanceContext())
            {
                context.Entry(reservation).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Reservation reservation)
        {
            using (var context = new MaintenanceContext())
            {
                context.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
