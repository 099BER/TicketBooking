using System;
using System.Collections.Generic;
using System.Linq;
namespace TicketBookingServer.Models
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> AllGenres { get; }
        public Genre GetGenreById(int id);
    }
}
