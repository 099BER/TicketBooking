using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketBookingServer.Models
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _appDbContext;
        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Movie> AllMovies => _appDbContext.Movies.Include(c => c.Genre);

        public bool AddMovie(Movie movie)
        {
            try
            {
                _appDbContext.Movies.Add(movie);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMovie(Movie movie)
        {
            try
            {
                _appDbContext.Movies.Remove(movie);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Movie GetMovieById(int id)
        {
            return _appDbContext.Movies.Include(c => c.Genre).FirstOrDefault(m => m.MovieId == id);
        }

        public bool UpdateMovie(Movie movie)
        {
            try
            {
                _appDbContext.Movies.Update(movie);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
