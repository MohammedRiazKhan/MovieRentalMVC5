using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_Rental.Models;


namespace Movie_Rental.ViewModels
{
    public class RentalFormViewModel
    {

        public List<Customer> Customers { get; set; }
        public List<Movie> Movies { get; set; }
        public Rental Rental  { get; set; }
        public string TitleOfPage
        {
            get
            {
                if (Rental != null && Rental.RentalId != 0)
                {
                    return "Edit Rental";
                }

                return "New Rental";
            }
        }

    }
}