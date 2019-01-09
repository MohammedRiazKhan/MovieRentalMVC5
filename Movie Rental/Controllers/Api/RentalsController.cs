using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Movie_Rental.Models;
using AutoMapper;
using Movie_Rental.Dtos;

namespace Movie_Rental.Controllers.Api
{
    public class RentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //get all movies /api/movie
        public IEnumerable<RentalDto> GetRentals()
        {
            return _context.Rentals.ToList().Select(Mapper.Map<Rental, RentalDto>);
        }

        //single rental
        public RentalDto GetRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(c => c.RentalId == id);

            if (rental == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Rental, RentalDto>(rental);
        }

        //post /api/rentals
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var rental = Mapper.Map<RentalDto, Rental>(rentalDto);

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            rentalDto.RentalId = rental.RentalId;

            return Created(new Uri(Request.RequestUri + "/" + rental.RentalId), rentalDto);

        }

        //put /api/rentals/1
        [HttpPut]
        public void UpdateRental(int id, RentalDto rental)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            }

            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.RentalId == id);

            if (rentalInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<RentalDto, Rental>(rental, rentalInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteRental(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.RentalId == id);

            if (rentalInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
        }




    }
}
