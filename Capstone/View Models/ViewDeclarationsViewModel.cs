using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.View_Models
{
    public class ViewDeclarationsViewModel
    {
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<ExpenseType> ExpenseTypes { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public Employee Employee { get; set; }
    }
}