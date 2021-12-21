using System;
using System.Collections.Generic;
using System.Linq;
namespace TicketBookingServer.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> AllMovies { get; }

        Movie GetMovieById(int id);
        bool DeleteMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool AddMovie(Movie movie);

    }
}
