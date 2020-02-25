using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Customer> Customers { get; set; }
        public DayOfWeek SelectedDay { get; set; }
        


    }
}
