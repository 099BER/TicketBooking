using System.Collections.Generic;
using TicketBookingServer.Models;

namespace TicketBookingServer.ViewModels
{
    public class MovieAddEditViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
