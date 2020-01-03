using MaintenanceService.Data.Entity;
using MaintenanceService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.EF.Repositories
{
    public class CarRepository : ICarRepository
    {
        public void Create(Car car)
        {
            using(var context = new MaintenanceContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        public Car Get(int id)
        {
            using (var context = new MaintenanceContext())
            {
                return context.Cars.FirstOrDefault(c => c.Id == id);
            }
        }

        public List<Car> GetCars()
        {
            using (var context = new MaintenanceContext())
            {
                return context.Cars.ToList();
            }
        }
    }
}
