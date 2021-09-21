using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.View_Models
{
    public class NewDeclarationViewModel
    {
        public IEnumerable<ExpenseType> ExpenseTypes { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public Expense Expense { get; set; }
        public Employee Employee { get; set; }
    }
}