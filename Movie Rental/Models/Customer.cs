using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie_Rental.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        //[Range(1, 10, ErrorMessage ="Phone Number must be 10 digits")]
        [Display(Name ="Phone Number")]
       
        public string PhoneNumber { get; set; }

        public double Credit { get; set; } = 100;

        [Display(Name ="Can Rent")]
        public bool CanRent { get; set; } = true;

    }
}