using HotelListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> hotels { get; }
        Task Save();
    }
}
