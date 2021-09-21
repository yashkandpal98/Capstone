using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.View_Models
{
    public class SearchEmployeesViewModel
    {
        public Manager Manager { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}