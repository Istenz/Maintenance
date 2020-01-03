using MaintenanceService.Data.Entity;
using MaintenanceService.Data.Repositories;
using MaintenanceService.Domain.Interfaces;
using MaintenanceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceService.Controllers
{
    public class HomeController : Controller
    {
        private IReservationService reservationService;
        private IMaintenanceService maintenanceService;
        private IReservationRepository reservationRepository;
        private IMaintenanceRepository maintenanceRepository;
        private ICarRepository carRepository;
        private ICustomerRepository customerRepository;
        private IMasterRepository masterRepository;
        public HomeController(
            IReservationService reservationService,
            IMaintenanceService maintenanceService, 
            IReservationRepository reservationRepository,
            IMaintenanceRepository maintenanceRepository,
            ICarRepository carRepository,
            ICustomerRepository customerRepository,
            IMasterRepository masterRepository)
        {
            this.reservationService = reservationService;
            this.maintenanceService = maintenanceService;
            this.reservationRepository = reservationRepository;
            this.maintenanceRepository = maintenanceRepository;
            this.carRepository = carRepository;
            this.customerRepository = customerRepository;
            this.masterRepository = masterRepository;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel {CurrentWeek = new List<DateTime>() };
            for(var cd = DateTime.Now; cd < DateTime.Now.AddDays(7); cd = cd.AddDays(1))
            {
                model.CurrentWeek.Add(cd);
            }
            return View(model);
        }

        public ActionResult TimesForDay(DateTime date)
        {
            var model = new TimesForDayViewModel { IsReservedTimes = new Dictionary<DateTime, bool>() };
            for(var dt = date.Date.AddHours(9); dt.Hour <= 18; dt = dt.AddHours(1))
            {
                model.IsReservedTimes.Add(dt, reservationService.TimeIsReserved(dt));
            }
            return View(model);
        }

        public ActionResult Reservation(DateTime? dateTime)
        {
            var reservation = reservationService.Reserve(dateTime.Value);
            var model = new ReservationViewModel { Reservation = reservation };
            return View(model);
        }

        [HttpPost]
        public ActionResult Reservation(Car car, Customer customer, int reservationId )
        {
            if (masterRepository.GetMasters().Any(m => m.CarBrand == car.Brand))
            {
                carRepository.Create(car);
                customerRepository.Create(customer);
                var reservation = reservationRepository.Get(reservationId);
                var maintenance = maintenanceService.Create(car.Id, customer.Id, reservation);
                return RedirectToAction("Masters", new { maintenanceId = maintenance.Id });
            }

            return RedirectToAction("NoMaster", new { reservationId = reservationId });
        }

        public ActionResult Masters(int maintenanceId)
        {
            var maintenance = maintenanceRepository.Get(maintenanceId);
            var car = carRepository.Get(maintenance.CarId);
            var masters = masterRepository.GetMasters().Where(m => m.CarBrand == car.Brand).ToList();
            var model = new ChooseMasterViewModel
            {
                MaintenanceId = maintenanceId,
                Masters = masters
            };
            return View(model);
        }

        public ActionResult ChooseMaster(int masterId, int maintenanceId)
        {
            var maintenance = maintenanceRepository.Get(maintenanceId);
            maintenance.MasterId = masterId;
            maintenanceRepository.Update(maintenance);
            return RedirectToAction("MaintenanceDetails", new { maintenanceId = maintenanceId});
        }

        public ActionResult NoMaster(int reservationId)
        {
            var reservation = reservationRepository.Get(reservationId);
            reservationRepository.Remove(reservation);
            return View();
        }

        public ActionResult MaintenanceDetails(int maintenanceId)
        {
            var maintenance = maintenanceRepository.Get(maintenanceId);
            var car = carRepository.Get(maintenance.CarId);
            var customer = customerRepository.Get(maintenance.CustomerId);
            var master = masterRepository.Get(maintenance.MasterId.Value);
            var model = new MaintanceDetailsViewModel
            {
                Car = car,
                CustomerName = customer.Name,
                CustomerSurname = customer.Surname,
                Master = master,
                DateTime = maintenance.DateTime
            };
            return View(model);
        }
    }
}