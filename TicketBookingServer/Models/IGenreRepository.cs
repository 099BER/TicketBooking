using System;
using System.Collections.Generic;
using System.Linq;
namespace TicketBookingServer.Models
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> AllGenres { get; }
    }
}
