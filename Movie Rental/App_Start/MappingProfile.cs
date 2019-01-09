using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Movie_Rental.Dtos;
using Movie_Rental.Models;

namespace Movie_Rental.App_Start
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            //domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Rental, RentalDto>();

            //dto to domain
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<RentalDto, Rental>();
        }
        

    }
}