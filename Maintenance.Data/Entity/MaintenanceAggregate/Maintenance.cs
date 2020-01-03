using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.Data.Entity
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }
        public int? MasterId { get; set; }
    }
}
