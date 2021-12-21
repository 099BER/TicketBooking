using System.Collections.Generic;
using TicketBookingServer.Models;

namespace TicketBookingServer.ViewModels
{
    public class TheatreManagementViewModel
    {
        public IEnumerable<Theatre> Theatres { get; set; }
        public IEnumerable<SeatingConfig> SeatingConfigs { get; set; }
    }
}
