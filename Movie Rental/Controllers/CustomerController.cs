using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie_Rental.Models;
using Movie_Rental.ViewModels;
namespace Movie_Rental.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult NewCustomer()
        {

            var viewModel = new CustomerFormViewModel
            {

                Customer = new Customer()

            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost] //never allow to be accessed by httpget
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var vModel = new CustomerFormViewModel();
                vModel.Customer = customer;

                return View("CustomerForm", vModel);
            }

            if(customer.CustomerId == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var cusInDb = _context.Customers.Single(c => c.CustomerId == customer.CustomerId);

                cusInDb.FirstName = customer.FirstName;
                cusInDb.LastName = customer.LastName;
                cusInDb.PhoneNumber = customer.PhoneNumber;
                
                cusInDb.Credit = customer.Credit;
                cusInDb.CanRent = customer.CanRent;

            }
            
            _context.SaveChanges();

            return RedirectToAction("CustomerList", "Customer"); 
        }

        public ActionResult CustomerList()
        {

            var customers = _context.Customers;

            return View(customers);
        }

        public ActionResult EditCustomer(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }

       

    }
}