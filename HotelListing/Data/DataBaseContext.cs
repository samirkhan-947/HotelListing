using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Country> countries { get; set; }
        public DbSet<Hotel> hotels { get; set; }
    }
}
