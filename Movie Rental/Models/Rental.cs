using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Movie_Rental.Models
{
    public class Rental
    {

        public int RentalId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int MovieId { get; set; }

        public string DateRented { get; set; }

        public string DateReturned { get; set; } = "N/A";

    }
}