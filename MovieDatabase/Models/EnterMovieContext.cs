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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating (ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category {  CategoryId=1, CategoryName="Action"},
                new Category { CategoryId=2, CategoryName="Comedy"},
                new Category { CategoryId=3, CategoryName="Mystery"},
                new Category { CategoryId=4, CategoryName="Drama"},
                new Category { CategoryId = 5, CategoryName = "Horror" },
                new Category { CategoryId = 6, CategoryName = "Romance" },
                new Category { CategoryId = 7, CategoryName = "Other" }

            );

            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieID = 1,
                    CategoryId = 1,
                    Title = "Top Gun: Maverick",
                    Year = 2022,
                    Director = "Joseph Kosinski",
                    Rating = "PG-13"
                },
                new MovieResponse
                {
                    MovieID = 2,
                    CategoryId = 3,
                    Title = "Glass Onion",
                    Year = 2022,
                    Director = "Rian Johnson",
                    Rating = "PG-13"
                },
                new MovieResponse
                {
                    MovieID = 3,
                    CategoryId = 4,
                    Title = "A Man Called Otto",
                    Year = 2022,
                    Director = "Marc Forster",
                    Rating = "PG-13"
                }
            );
        } 
    }
}
