using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie_Rental.Dtos
{
    public class CustomerDto
    {


        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        //[Range(1, 10, ErrorMessage ="Phone Number must be 10 digits")]
        
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        
        public string AccountType { get; set; }

        public double Credit { get; set; } = 100;

        
        public bool CanRent { get; set; } = true;


    }
}