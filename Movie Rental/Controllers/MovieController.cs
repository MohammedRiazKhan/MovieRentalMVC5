using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie_Rental.Models;
using Movie_Rental.ViewModels;


namespace Movie_Rental.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult NewMovie()
        {

            var viewModel = new MovieFormViewModel
            {

                Movie = new Movie()

            };

            return View("MovieForm", viewModel);
        }

        [HttpPost] //never allow to be accessed by httpget
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var vModel = new MovieFormViewModel();
                vModel.Movie = movie;

                return View("MovieForm", vModel);
            }

            if (movie.MovieId == 0)
            {

                if(movie.NewRelease == true)
                {
                    movie.Price = 15;
                }

                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.MovieId == movie.MovieId);

                movieInDb.Title = movie.Title;
                
                movieInDb.Genre = movie.Genre;
                movieInDb.Price = movie.Price;
                movieInDb.ReleaseYear = movie.ReleaseYear;
                movieInDb.AvailableForRent = movie.AvailableForRent;
                movieInDb.NewRelease = movie.NewRelease;

            }

            _context.SaveChanges();

            return RedirectToAction("MovieList", "Movie");
        }

        public ActionResult MovieList()
        {
            var movies = _context.Movies;


            if (User.IsInRole(RoleName.CanManageMovies))
            {

                return View("MovieList", movies);

            }

            return View("ReadOnlyList", movies);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie
            };

            return View("MovieForm", viewModel);
        }

    }
}