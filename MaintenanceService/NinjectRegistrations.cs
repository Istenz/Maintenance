using MaintenanceService.Data.Repositories;
using MaintenanceService.Domain.Interfaces;
using MaintenanceService.Domain.Services;
using MaintenanceService.EF.Repositories;
using Ninject.Modules;

namespace MaintenanceService
{
    internal class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IReservationRepository>().To<ReservationRepository>();
            Bind<IMaintenanceRepository>().To<MaintenanceRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<ICarRepository>().To<CarRepository>();
            Bind<IMasterRepository>().To<MasterRepository>();

            Bind<IMaintenanceService>().To<MaintenanceService.Domain.Services.MaintenanceService>();
            Bind<IReservationService>().To<ReservationService>();
        }
    }
}