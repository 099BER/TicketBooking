using System;
using System.Collections.Generic;
using TicketBookingServer.Models;

namespace TicketBookingServer.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Screening> Screenings { get; set; }
        public IEnumerable<DateTime> Dates { get; set; }
    }
}
