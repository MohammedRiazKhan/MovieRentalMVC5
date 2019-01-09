using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Movie_Rental.Models
{
    public class Movie
    {

        private bool newRelease;
        private double price = 10;

        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Genre { get; set; }


        [Range(5, 10)]
        public double Price
        {
            get { return price; }
            set { price = NewRelease == true ? 10 : 10; }
        } 

        [Required]
        [Range(1975, 2019)]
        
        [Display(Name ="Release Year")]
        public int ReleaseYear { get; set; }

        [Display(Name ="Available For Rent")]
        public bool AvailableForRent { get; set; } = true;

        [Display(Name ="New Release")]
        public bool NewRelease {

            get { return newRelease; }
            set { newRelease = ReleaseYear >= 2018 ? true : false; }

        }
    }

}