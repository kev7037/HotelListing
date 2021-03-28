using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) {}

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Iran",
                    ShortName = "IR"
                },
                new Country
                {
                    Id = 2,
                    Name = "Canada",
                    ShortName = "CA"
                },
                new Country
                {
                    Id = 3,
                    Name = "Turkey",
                    ShortName = "TR"
                }
            );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Iran",
                    Address = "Tehran Hotel",
                    CountryId = 1,
                    Rating = 3.1
                   
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Canada",
                    Address = "Toronto Hotel",
                    CountryId = 2,
                    Rating = 4.3
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Turkey",
                    Address = "Istanbul Hotel",
                    CountryId = 3,
                    Rating = 4.5
                }
            );


        }

    }
}
