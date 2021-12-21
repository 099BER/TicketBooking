using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketBookingServer.Models
{
    public class TheatreRepository : ITheatreRepository
    {
        private readonly AppDbContext _appDbContext;
        public TheatreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Theatre> AllTheatres => _appDbContext.Theatres.Include(c => c.SeatingConfig);

        public bool AddTheatre(Theatre theatre)
        {
            try
            {
                _appDbContext.Theatres.Add(theatre);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteTheatre(Theatre theatre)
        {
            try
            {
                _appDbContext.Theatres.Remove(theatre);
                _appDbContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Theatre GetTheatrebyId(int theatreId)
        {
            return _appDbContext.Theatres.Include(c => c.SeatingConfig).FirstOrDefault(c => c.TheatreId == theatreId);
        }

        public bool UpdateTheatre(Theatre theatre)
        {
            try
            {
                _appDbContext.Theatres.Update(theatre);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
