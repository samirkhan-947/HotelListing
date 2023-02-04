using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
