using Movie_Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Movie_Rental.Dtos;
using AutoMapper;

namespace Movie_Rental.Controllers.Api
{
    public class CustomersController : ApiController
    { 
        //
        /*
            domain models should never be used for apis
            instead in asp.net use dto(domain transfer objects)
        */

        private ApplicationDbContext _context;

        public CustomersController()
        {

            _context = new ApplicationDbContext();

        }

        //get all customers /api/customer
        public IHttpActionResult GetCustomers(string query = null)
        {

            var customersQuery = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.FirstName.Contains(query));
            }

            return Ok(customersQuery);
        }

        //single customer
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if(customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.CustomerId = customer.CustomerId;

            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customerDto);

        }

        //put /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customer)
        {

            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            }

            var cusInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if(cusInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CustomerDto, Customer>(customer, cusInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var cusInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (cusInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(cusInDb);
            _context.SaveChanges();
        }

    }
}
