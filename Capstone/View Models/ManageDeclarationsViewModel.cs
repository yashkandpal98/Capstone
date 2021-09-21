using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.View_Models
{
    public class ManageDeclarationsViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public Manager Manager { get; set; }
    }
}