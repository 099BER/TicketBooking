using System;

namespace TicketBookingServer.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
