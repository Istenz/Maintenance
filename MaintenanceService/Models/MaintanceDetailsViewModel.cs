using MaintenanceService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceService.Models
{
    public class MaintanceDetailsViewModel
    {
        public Car Car{ get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public DateTime DateTime { get; set; }
        public Master Master { get; set; }
    }
}