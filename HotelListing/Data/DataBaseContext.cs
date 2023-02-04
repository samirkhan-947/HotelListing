using HotelListing.Entities;
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
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
