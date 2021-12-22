using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketBookingServer.Models
{
    public interface IScreeningRepository
    {
        IEnumerable<Screening> AllScreening { get; }
        Screening GetScreeningById(int screeningId);

        bool DeleteScreening(Screening screeningId);
        bool AddScreening(Screening screening);
    }
}
