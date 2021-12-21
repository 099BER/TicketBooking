using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public class SeatingConfigRepository : ISeatingConfigRepository
    {
        private readonly AppDbContext _appDbContext;
        public SeatingConfigRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<SeatingConfig> AllSeatingConfigs => _appDbContext.SeatingConfigs;

        public SeatingConfig GetSeatingConfig(int seatingConfigId) => _appDbContext.SeatingConfigs.Find(seatingConfigId);
    }
}
