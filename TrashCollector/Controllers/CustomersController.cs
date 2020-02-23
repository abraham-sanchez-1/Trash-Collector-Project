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
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            
            _context = context;
        }

        // GET: Customers
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.FirstOrDefault(a=> a.UserId == userId);
            if (customer is null)
            {
                return RedirectToAction("Create");
            }
            


            return RedirectToAction("Edit");
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var address = customerViewModel.Address;
                _context.Addresses.Add(address);
                _context.SaveChanges();

                var customer = customerViewModel.Customer;

                customer.AddressId = address.Id;
                customer.UserId = userId;
                customer.LastPickedUp = DateTime.Today;
                _context.Customers.Add(customer);
                
                
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            return View(customerViewModel);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.FirstOrDefault(a => a.UserId == userId);
            var existingModel = new CustomerViewModel();
            existingModel.Customer = customer;
            existingModel.Address = _context.Addresses.FirstOrDefault(a => a.Id == customer.AddressId);

            
            return View(existingModel);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel customerViewModel)
        {
            var address = customerViewModel.Address;
            var customer = customerViewModel.Customer;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var addressId = customer.AddressId;
            Customer customerToBeUpdated = _context.Customers.Where(a => a.UserId == userId).FirstOrDefault();
            customerToBeUpdated.PickUpDay = customer.PickUpDay;
            customerToBeUpdated.SuspendStart = customer.SuspendStart;
            customerToBeUpdated.SuspendEnd = customer.SuspendEnd;
            Address addressToBeChanged = _context.Addresses.Where(a => a.Id == addressId).FirstOrDefault();
            addressToBeChanged.StreetName = address.StreetName;
            addressToBeChanged.City = address.City;
            addressToBeChanged.State = address.State;
            addressToBeChanged.ZipCode = address.ZipCode;
                
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //// GET: Customers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customers
        //        .Include(c => c.Address)
        //        .Include(c => c.IdentityUser)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        //// POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);
        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
