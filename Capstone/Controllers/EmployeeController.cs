using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;
using Capstone.View_Models;

namespace Capstone.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispoosing)
        {
            _context.Dispose();
        }

        // GET: Employee
        public ActionResult Index()
        {
            var sampleEmployee = _context.Employees.Single(c => c.EmployeeId == 1);

            return View(sampleEmployee);
        }

        public ActionResult NewDeclaration()
        {
            var expenseTypes = _context.ExpenseTypes.ToList();
            var statuses = _context.Statuses.ToList();
            var employee = _context.Employees.Single(c => c.EmployeeId == 1);
            var expense = new Expense
            {
                EmployeeId = employee.EmployeeId
            };

            var newEnquiryViewModel = new NewDeclarationViewModel
            {
                Expense = expense,
                ExpenseTypes = expenseTypes,
                Statuses = statuses,
                Employee = employee
            };

            return View(newEnquiryViewModel);
        }

        [HttpPost]
        public ActionResult Save(Expense expense)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewDeclarationViewModel
                {
                    Expense = expense,
                    ExpenseTypes = _context.ExpenseTypes.ToList(),
                    Statuses = _context.Statuses.ToList(),
                    Employee = _context.Employees.Single(c => c.EmployeeId == expense.EmployeeId)
                };

                return View("NewDeclaration", viewModel);
            }

            expense.DateSubmitted = DateTime.Now;

            expense.StatusId = 1;

            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return RedirectToAction("ViewDeclarations", "Employee");
        }

        public ActionResult ViewDeclarations()
        {
            var expenses = _context.Expenses.ToList();
            var employee = _context.Employees.Single(c => c.EmployeeId == 1);
            var expenseTypes = _context.ExpenseTypes.ToList();
            var statuses = _context.Statuses.ToList();

            var viewEnquiryViewModel = new ViewDeclarationsViewModel
            {
                Expenses = expenses,
                Employee = employee,
                ExpenseTypes = expenseTypes,
                Statuses = statuses
            };

            return View(viewEnquiryViewModel);
        }
    }
}