using System.Collections.Generic;
using TicketBookingServer.Models;

namespace TicketBookingServer.ViewModels
{
    public class ManageBookingsViewModel
    {
        public IEnumerable<Order> orders { get; set; }
    }
}
