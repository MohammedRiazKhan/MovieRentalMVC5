using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_Rental.Models;


namespace Movie_Rental.ViewModels
{
    public class MovieFormViewModel
    {

        public Movie Movie { get; set; }
        public string TitleOfPage
        {
            get
            {
                if (Movie != null && Movie.MovieId != 0)
                {
                    return "Edit Movie";
                }

                return "New Movie";
            }
        }


    }
}