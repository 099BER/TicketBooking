using System;
using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public class Screening
    {
        public int ScreeningId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
        public DateTime ScreeningDateTime  { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
