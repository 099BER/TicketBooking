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
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = 3, GenreName = "Horror" });

            // Seed Seating cofig
            modelBuilder.Entity<SeatingConfig>().HasData(new SeatingConfig { SeatingConfigId = 1, NumberOfSeats = 10 });
            modelBuilder.Entity<SeatingConfig>().HasData(new SeatingConfig { SeatingConfigId = 2, NumberOfSeats = 20 });

            // Seed theatres
            modelBuilder.Entity<Theatre>().HasData(new Theatre { TheatreId = 1, Name = "Small Screen", SeatingConfigId = 1 });
            modelBuilder.Entity<Theatre>().HasData(new Theatre { TheatreId = 2, Name = "Large Screen", SeatingConfigId = 2 });

            // Seed screenings
            modelBuilder.Entity<Screening>().HasData(new Screening { ScreeningId = 1, TheatreId = 1, MovieId = 1, ScreeningDateTime = new DateTime(2021, 12, 25, 10, 00, 00) });
            modelBuilder.Entity<Screening>().HasData(new Screening { ScreeningId = 2, TheatreId = 1, MovieId = 1, ScreeningDateTime = new DateTime(2021, 12, 26, 10, 00, 00) });
            modelBuilder.Entity<Screening>().HasData(new Screening { ScreeningId = 3, TheatreId = 2, MovieId = 2, ScreeningDateTime = new DateTime(2021, 12, 25, 10, 00, 00) });
            modelBuilder.Entity<Screening>().HasData(new Screening { ScreeningId = 4, TheatreId = 2, MovieId = 3, ScreeningDateTime = new DateTime(2021, 12, 26, 10, 00, 00) });

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 1,
                Title = "Movie 1: First Movie",
                Price = 20,
                Description = "The first movie ever created.",
                GenreId = 1,
                ImageUrl = "https://demostorelokesh12.blob.core.windows.net/images/prawns.jpg",
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 2,
                Title = "Movie 2: Second Movie",
                Price = 20,
                Description = "The second movie ever created.",
                GenreId = 2,
                ImageUrl = "https://demostorelokesh12.blob.core.windows.net/images/prawns.jpg",
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 3,
                Title = "Movie 3: Third Movie",
                Price = 20,
                Description = "The third movie ever created.",
                GenreId = 3,
                ImageUrl = "https://demostorelokesh12.blob.core.windows.net/images/prawns.jpg",
            });
        }
    }
}
