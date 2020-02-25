using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.FirstOrDefault(a => a.UserId == userId);
            if (employee is null)
            {
                return RedirectToAction("Create");
            }


            return RedirectToAction("Edit");
        }
        //Get: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var employee = employeeViewModel.Employee;
                employee.UserId = userId;
                _context.Employees.Add(employee);


                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        // GET: Employees/Edit/5
        public IActionResult Edit()
        {
           var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.FirstOrDefault(a => a.UserId == userId);
            var currentDay = DateTime.Now.DayOfWeek;
            var customer = _context.Customers
                .Include(c => c.Address)
                .Where(a => a.Address.ZipCode == employee.ZipCode && (a.PickUpDay == currentDay || a.OneTimePickUp == DateTime.Now.Date) && (a.IsSuspended == false))
                .ToList();
            var existingModel = new EmployeeViewModel();
            existingModel.Employee = employee;
            existingModel.Customers = customer;
            return View(existingModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employeeModel)
        {


            return View(employeeModel);
           
        }
        public IActionResult FilterByDay (EmployeeViewModel employeeModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.FirstOrDefault(a => a.UserId == userId);
            var currentDay = employeeModel.SelectedDay;
            var customer = _context.Customers
                .Include(c => c.Address)
                .Where(a => a.Address.ZipCode == employee.ZipCode && (a.PickUpDay == currentDay) && (a.IsSuspended == false))
                .ToList();
            var existingModel = new EmployeeViewModel();
            existingModel.Employee = employee;
            existingModel.Customers = customer;
            existingModel.SelectedDay = currentDay;
            return View("Edit",existingModel);
        }
        public IActionResult ConfirmPickup (int Id)
        {
            Customer customer = _context.Customers.FirstOrDefault(a => a.Id == Id);
            customer.LastPickedUp = DateTime.Now;
            customer.Balance += 15;
            _context.SaveChanges();

            return RedirectToAction(nameof(Edit));
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
