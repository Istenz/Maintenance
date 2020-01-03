using MaintenanceService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.Data.Repositories
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        Customer Get(int id);
        List<Customer> GetCustomers();
    }
}
