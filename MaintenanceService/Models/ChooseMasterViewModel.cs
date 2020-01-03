using MaintenanceService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceService.Models
{
    public class ChooseMasterViewModel
    {
        public int MaintenanceId { get; set; }
        public List<Master> Masters{ get; set; }
    }
}