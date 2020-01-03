using MaintenanceService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.Data.Repositories
{
    public interface ICarRepository
    {
        void Create(Car car);
        Car Get(int id);
        List<Car> GetCars();
    }
}
