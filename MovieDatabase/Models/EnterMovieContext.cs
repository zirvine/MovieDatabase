using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Models
{
    public class EnterMovieContext : DbContext
    {
        //Contructor
        public EnterMovieContext (DbContextOptions<EnterMovieContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<MovieResponse> responses { get; set; }

        protected override void OnModelCreating (ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieID = 1,
                    Category = "Action",
                    Title = "Top Gun: Maverick",
                    Year = 2022,
                    Director = "Joseph Kosinski",
                    Rating = "PG-13"
                },
                new MovieResponse
                {
                    MovieID = 2,
                    Category = "Mystery/Comedy",
                    Title = "Glass Onion",
                    Year = 2022,
                    Director = "Rian Johnson",
                    Rating = "PG-13"
                },
                new MovieResponse
                {
                    MovieID = 3,
                    Category = "Comedy/Drama",
                    Title = "A Man Called Otto",
                    Year = 2022,
                    Director = "Marc Forster",
                    Rating = "PG-13"
                }
            );
        } 
    }
}
