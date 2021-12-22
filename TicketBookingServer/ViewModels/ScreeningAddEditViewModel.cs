using System;
using System.Collections.Generic;
using TicketBookingServer.Models;

namespace TicketBookingServer.ViewModels
{
    public class ScreeningAddEditViewModel
    {
        public Screening Screening { get; set; }
        public IEnumerable<Theatre> TheatreList { get; set; }
        public IEnumerable<Movie> MovieList { get; set; }
    }
}
