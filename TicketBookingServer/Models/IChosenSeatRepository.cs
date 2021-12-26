using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public interface IChosenSeatRepository
    {
        public List<int> GetOccupiedSeatsByScreeningId(int screeningId);
    }
}
