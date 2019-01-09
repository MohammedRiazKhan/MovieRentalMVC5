using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Movie_Rental.Dtos
{
    public class MovieDto
    {

        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Genre { get; set; }

        [Required]
        [Range(0, 50)]
        public double Price { get; set; }

        [Required]
        [Range(1975, 2019)]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Available For Rent")]
        public bool AvailableForRent { get; set; } = true;

        [Display(Name = "New Release")]
        public bool NewRelease { get; set; }

    }
}