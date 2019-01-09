using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Movie_Rental.Models;

namespace Movie_Rental.Dtos
{
    public class RentalDto
    {

        public int RentalId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

    }
}