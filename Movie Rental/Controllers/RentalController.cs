using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie_Rental.Models;
using Movie_Rental.ViewModels;

namespace Movie_Rental.Controllers
{
    public class RentalController : Controller
    {

        private ApplicationDbContext _context;

        public RentalController()
        {

            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult NewRental()
        {
            var customersInDB = _context.Customers.Where(c => c.CanRent == true).ToList();
            var moviesInDB = _context.Movies.Where(m => m.AvailableForRent == true).ToList();

            if(customersInDB == null)
            {
                return View("NoCustomers");
            }
            else if(moviesInDB == null)
            {
                return View("NoMovies");
            }
            else if(customersInDB == null && moviesInDB == null)
            {
                return View("NothingYet");
            }

            else
            {
                var viewModel = new RentalFormViewModel
                {
                    Rental = new Rental(),
                    Customers = customersInDB,
                    Movies = moviesInDB
                };


                return View("RentalFormView", viewModel);
            }
            
        }

        [HttpPost] //never allow to be accessed by httpget
        [ValidateAntiForgeryToken]
        public ActionResult Save(Rental rental, String Cus, String Mov)
        {

            //changes values?
            rental.CustomerId = Convert.ToInt32(Cus);
            rental.MovieId = Convert.ToInt32(Mov);

            DateTime now = DateTime.Now;

            rental.DateRented = now.ToShortDateString();

            if (!ModelState.IsValid)
            {
                var vModel = new RentalFormViewModel
                {
                    Rental = rental
                    
                };


                return View("RentalFormView", vModel);
            }

            if (rental.RentalId == 0)
            {
                _context.Rentals.Add(rental);

                var customerInDb = _context.Customers.Single(c => c.CustomerId == rental.CustomerId);

                var movieInDb = _context.Movies.Single(m => m.MovieId == rental.MovieId);

                customerInDb.CanRent = false;
                movieInDb.AvailableForRent = false;
                customerInDb.Credit -= movieInDb.Price; 

            }
            else
            {
                var rentalInDb = _context.Rentals.Single(r => r.RentalId == rental.RentalId);
                rentalInDb.CustomerId = rental.CustomerId;
                rentalInDb.MovieId = rental.MovieId;
                rentalInDb.DateRented = rental.DateRented;
                rentalInDb.DateReturned = rental.DateReturned; 

            }

            _context.SaveChanges();

            return RedirectToAction("RentalList", "Rental");
        }

        public ActionResult RentalList()
        {
            var rentals = _context.Rentals;

            return View(rentals);
        }

        public ActionResult EditRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.RentalId == id);

            if (rental == null)
            {
                return HttpNotFound();
            }

            var viewModel = new RentalFormViewModel
            {
                Rental = rental
            };

            return View("RentalFormView", viewModel);
        }

        public ActionResult ReturnRental(int id)
        {

            var rental = _context.Rentals.SingleOrDefault(r => r.RentalId == id);

            DateTime now = DateTime.Now;

            rental.DateReturned = now.ToShortDateString();

            if (rental == null)
            {
                return HttpNotFound();
            }

            var customerInDb = _context.Customers.Single(c => c.CustomerId == rental.CustomerId);

            var movieInDb = _context.Movies.Single(m => m.MovieId == rental.MovieId);

            customerInDb.CanRent = true;
            movieInDb.AvailableForRent = true;

            _context.SaveChanges();

            return RedirectToAction("RentalList", "Rental");
        }

        //public ActionResult RentalForm()
        //{
        //    return View();
        //}

        //public ActionResult NewRental()
        //{
        //    var customersInDB = _context.Customers.ToList();
        //    var moviesInDB = _context.Movies.ToList();

        //    var viewModel = new RentalFormViewModel
        //    {
        //        Rental = new Rental(),
        //        Customers = customersInDB,
        //        Movies = moviesInDB
        //    };


        //    return View("RentalForm", viewModel);
        //}

        //public ActionResult RentalList()
        //{

        //    var rentals = _context.Rentals;

        //    return View(rentals);
        //}

    }
}