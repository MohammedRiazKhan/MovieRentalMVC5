//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using Movie_Rental.Dtos;
//using Movie_Rental.Models;

//namespace Movie_Rental.Controllers.Api
//{
//    public class NewRentalsController : ApiController
//    {

//        private ApplicationDbContext _context;

//        public NewRentalsController()
//        {
//            _context = new ApplicationDbContext();
//        }

//        //to comply with restful conventions
//        [HttpPost]
//        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
//        {

//            var customer = _context.Customers.Single(c => c.CustomerId == newRental.CustomerId);

//            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.MovieId)).ToList();

//            foreach(var movie in movies)
//            {
//                var rental = new Rental
//                {
//                    Customer = customer,
//                    Movie = movie,
//                    DateRented = DateTime.Now
//                };

//                _context.Rentals.Add(rental);

//            }

//            _context.SaveChanges();

//            return Ok();

//        }

//    }
//}
