using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketBookingServer.Models
{
    public interface ITheatreRepository
    {
        IEnumerable<Theatre> AllTheatres { get; }
        Theatre GetTheatrebyId(int theatreId);
        bool AddTheatre(Theatre theatre);
        bool DeleteTheatre(Theatre theatre);
        bool UpdateTheatre(Theatre theatre);
    }
}
