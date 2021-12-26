using System.Collections.Generic;
using System.Linq;

namespace TicketBookingServer.Models
{
    public class ChosenSeatRepository: IChosenSeatRepository
    {
        private readonly AppDbContext _appDbContext;

        public ChosenSeatRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<int> GetOccupiedSeatsByScreeningId(int screeningId)
        {
            return _appDbContext.ChosenSeats.Where(c => c.ScreeningId == screeningId).Select(c => c.SeatNumber).ToList();
        }
    }
}
