using HotelListing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DataBaseContext:IdentityDbContext<ApiUser>
    {
        public DataBaseContext(DbContextOptions options):base(options)
        {

        }

       
        public DbSet<Country> countries { get; set; }
        public DbSet<Hotel> hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "India",
                    ShortName = "Ind"
                },
                new Country
                {
                    Id = 2,
                    Name = "Pakistan",
                    ShortName = "Pak"
                },
                new Country
                {
                    Id = 3,
                    Name = "Nepal",
                    ShortName = "Nep"
                }
            );
            modelBuilder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "patna hotel",
                   Address = "patna",
                   Rating = 4.5,
                   CountryId = 1

               },
               new Hotel
               {
                   Id = 2,
                   Name = "peshawar hotel",
                   Address = "peshawar",
                   Rating = 4.3,
                   CountryId = 2
               },
               new Hotel
               {
                   Id = 3,
                   Name = "kathmandu hotel",
                   Address = "kathmandu",
                   Rating = 4.2,
                   CountryId = 3
               }
           );
        }
    }
}
