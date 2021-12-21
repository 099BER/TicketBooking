using System.Collections.Generic;
using TicketBookingServer.Models;
namespace TicketBookingServer.ViewModels
{
    public class EditTheatreViewModel
    {
        public Theatre Theatre;
        public IEnumerable<SeatingConfig> SeatingConfigs;
    }
}
