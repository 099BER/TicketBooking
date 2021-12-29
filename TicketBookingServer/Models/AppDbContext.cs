using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace TicketBookingServer.Models
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Movie>  Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SeatingConfig> SeatingConfigs { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<ChosenSeat> ChosenSeats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed Genres
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = 1, GenreName = "Comedy" });
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = 2, GenreName = "Documentary" });
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = 3, GenreName = "Action" });
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = 4, GenreName = "Drama" });
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = 5, GenreName = "Fantasy" });
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = 6, GenreName = "Mystery" });
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = 7, GenreName = "Thriller" });

            // Seed Seating cofig
            modelBuilder.Entity<SeatingConfig>().HasData(new SeatingConfig { SeatingConfigId = 1, NumberOfSeats = 10 });
            modelBuilder.Entity<SeatingConfig>().HasData(new SeatingConfig { SeatingConfigId = 2, NumberOfSeats = 20 });

            // Seed theatres
            modelBuilder.Entity<Theatre>().HasData(new Theatre { TheatreId = 1, Name = "Small Screen", SeatingConfigId = 1 });
            modelBuilder.Entity<Theatre>().HasData(new Theatre { TheatreId = 2, Name = "Large Screen", SeatingConfigId = 2 });
        }
    }
}
