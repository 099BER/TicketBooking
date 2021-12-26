using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketBookingServer.Models;

namespace TicketBookingServer.ViewModels
{
    public class MovieAddEditViewModel
    {
        public Movie Movie { get; set; }
        [Range(0, 5)]
        public int Hours { get; set; }
        [Range(1, 59)]
        public int Minutes { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
