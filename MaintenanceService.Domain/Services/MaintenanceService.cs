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
    public class MaintenanceService : IMaintenanceService
    {
        private IMaintenanceRepository maintenanceRepository;
        private ICustomerRepository customerRepository;
        private IReservationRepository reservationRepository;

        public MaintenanceService( 
            IMaintenanceRepository maintenanceRepository, 
            ICustomerRepository customerRepository,
            IReservationRepository reservationRepository)
        {
            this.maintenanceRepository = maintenanceRepository;
            this.customerRepository = customerRepository;
            this.reservationRepository = reservationRepository;
        }

        public Maintenance Create(int carId, int customerId, Reservation reservation, int? masterId = null)
        {
            var maintenance = new Maintenance
            {
                CarId = carId,
                CustomerId = customerId,
                DateTime = reservation.ReservedDateTime,
                MasterId = masterId,
            };

            maintenanceRepository.Create(maintenance);
            reservation.MaintenanceId = maintenance.Id;
            reservationRepository.Update(reservation);

            return maintenance;
        }
    }
}
