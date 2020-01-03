using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceService.Data.Entity
{
    public class Master
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string CarBrand { get; set; }
    }
}
