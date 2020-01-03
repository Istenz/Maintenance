using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceService.Models
{
    public class TimesForDayViewModel
    {
        public Dictionary<DateTime,bool> IsReservedTimes { get; set; }
    }
}