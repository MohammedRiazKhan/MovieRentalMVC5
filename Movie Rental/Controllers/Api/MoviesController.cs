using Movie_Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Movie_Rental.Dtos;
using AutoMapper;

namespace Movie_Rental.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //get all movies /api/movie
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {

            var moviesQuery = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Title.Contains(query));
            }

            return moviesQuery;
        }

        //single customer
        public MovieDto GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Movie, MovieDto>(movie);
        }

        //post /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.MovieId = movie.MovieId;

            return Created(new Uri(Request.RequestUri + "/" + movie.MovieId), movieDto);

        }

        //put /api/customers/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movie)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<MovieDto, Movie>(movie, movieInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }

    }


}

