using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
