﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace TicketBookingServer.Models
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly AppDbContext _appDbContext;

        public ScreeningRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Screening> AllScreening => _appDbContext.Screenings.Include(c => c.Movie).Include(c => c.Theatre).Include(c => c.Theatre.SeatingConfig);


        public Screening GetScreeningById(int screeningId)
        {
            return _appDbContext.Screenings.Include(c => c.Movie).Include(c => c.Theatre).Include(c=>c.Theatre.SeatingConfig).FirstOrDefault(f => f.ScreeningId == screeningId);
        }
    }
}
