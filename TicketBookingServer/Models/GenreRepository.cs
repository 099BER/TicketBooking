using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _appDbContext;

        public GenreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Genre> AllGenres => _appDbContext.Genres;

        public Genre GetGenreById(int id) => _appDbContext.Genres.Find(id);
    }
}
