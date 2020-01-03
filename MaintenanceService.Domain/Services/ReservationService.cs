using MaintenanceService.Data.Entity;
using MaintenanceService.Data.Repositories;
using MaintenanceService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository reservationRepository;
        private IMaintenanceRepository maintenanceRepository;

        public ReservationService(IReservationRepository reservationRepository, IMaintenanceRepository maintenanceRepository)
        {
            this.reservationRepository = reservationRepository;
            this.maintenanceRepository = maintenanceRepository;
        }

        public Reservation Reserve(DateTime reservedDateTime)
        {
            var reservation = new Reservation
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(20),
                ReservedDateTime = reservedDateTime
            };

            reservationRepository.Create(reservation);

            return reservation;
        }

        public bool TimeIsReserved(DateTime time)
        {
            var hasReservation = reservationRepository.GetReservations()
                .Where(r => r.ReservedDateTime == time)
                .Any(r => r.EndTime > DateTime.Now);
            var hasMaintenance = maintenanceRepository.GetMaintenances().Any(m => m.DateTime == time);
            return hasReservation || hasMaintenance;
        }
    }
}
