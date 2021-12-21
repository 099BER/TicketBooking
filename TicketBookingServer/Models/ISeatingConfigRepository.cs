using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public interface ISeatingConfigRepository
    {
        public IEnumerable<SeatingConfig> AllSeatingConfigs { get; }
        public SeatingConfig GetSeatingConfig(int seatingConfigId);
    }
}
