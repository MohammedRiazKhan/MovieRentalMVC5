using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_Rental.Models;


namespace Movie_Rental.ViewModels
{
    public class CustomerFormViewModel
    {

        public Customer Customer { get; set; }
        public string TitleOfPage
        {
            get
            {
                if(Customer != null && Customer.CustomerId != 0)
                {
                    return "Edit Customer";
                }

                return "New Customer";
            }
        }

    }
}