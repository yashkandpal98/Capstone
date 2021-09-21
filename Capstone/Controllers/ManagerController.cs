using Capstone.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.View_Models;

namespace Capstone.Controllers
{
    public class ManagerController : Controller
    {
        private ApplicationDbContext _context;

        public ManagerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispoosing)
        {
            _context.Dispose();
        }

        // GET: Manager
        public ActionResult Index()
        {
            var manager = _context.Managers.Single(c => c.ManagerId == 1);

            return View(manager);
        }

        public ActionResult ManageDeclarations()
        {
            var employees = _context.Employees.ToList();
            var manager = _context.Managers.Single(c => c.ManagerId == 1);
            var expenses = _context.Expenses.ToList();

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].ManagerId == manager.ManagerId)
                    continue;

                employees.Remove(employees[i]);
            }

            var manageDeclarations = new ManageDeclarationsViewModel
            {
                Employees = employees,
                Manager = manager
            };

            return View(manageDeclarations);
        }

        public ActionResult ApproveOrReject(int id)
        {
            var employee = _context.Employees.Single(c => c.EmployeeId == id);
            var expenses = _context.Expenses.ToList();
            var statuses = _context.Statuses.ToList();
            var expenseTypes = _context.ExpenseTypes.ToList();

            for(int i = 0; i < expenses.Count; i++)
            {
                if (expenses[i].EmployeeId == employee.EmployeeId)
                    continue;
                expenses.Remove(expenses[i]);
            }

            var viewExpenses = new ViewDeclarationsViewModel
            {
                Employee = employee,
                Expenses = expenses,
                Statuses = statuses,
                ExpenseTypes = expenseTypes
            };

            return View(viewExpenses);
        }

        [HttpPost]
        public ActionResult Approve(Expense expense)
        {
            var expenseInDB = _context.Expenses.Single(c => c.ExpenseId == expense.ExpenseId);

            expenseInDB.StatusId = 2;

            _context.SaveChanges();

            return RedirectToAction("ManageDeclarations", "Manager");
        }

        [HttpPost]
        public ActionResult Reject(Expense expense)
        {
            var expenseInDB = _context.Expenses.Single(c => c.ExpenseId == expense.ExpenseId);

            expenseInDB.StatusId = 3;

            _context.SaveChanges();

            return RedirectToAction("ManageDeclarations", "Manager");
        }

        public ActionResult Search()
        {
            return View();
        }

        /*public ActionResult Search(string employeeName)
        {
            var employees = _context.Employees.ToList();
            var manager = _context.Managers.Single(c => c.ManagerId == 1)

            foreach (Employee employee in employees)
            {
                if (employee.Name.Contains(employeeName) && employee.ManagerId == manager.ManagerId)
                    continue;
                
                employees.Remove(employee);
            }

            return View(employees);
        }*/
    }
}