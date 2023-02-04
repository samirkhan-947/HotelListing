using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Entities
{
    public class CountryConfiguration:IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
