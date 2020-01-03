using MaintenanceService.Data.Entity;
using MaintenanceService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.EF.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Create(Customer customer)
        {
            using(var context = new MaintenanceContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public Customer Get(int id)
        {
            using (var context = new MaintenanceContext())
            {
                return context.Customers.FirstOrDefault(c => c.Id == id);
            }
        }

        public List<Customer> GetCustomers()
        {
            using (var context = new MaintenanceContext())
            {
                return context.Customers.ToList();
            }
        }
    }
}
