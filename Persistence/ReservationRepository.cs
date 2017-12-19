using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Core;
using vega.Core.Models;

namespace vega.Persistence
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly VegaDbContext context;
        public ReservationRepository(VegaDbContext context)
    {
        this.context = context;
    }

        public void Add(Reservation reservation)
        {
            context.Reservation.Add(reservation);
        }

        public async Task<Reservation> GetReservation(int id)
        {
            return await context.Reservation
          .Include(v => v.Vehicle)
          .Include(v => v.ParkingLot)
          .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
        return await context.Reservation
        .Include(v => v.Vehicle)
        .Include(v => v.ParkingLot)
        .ToListAsync();
        }

        public void Remove(Reservation reservation)
        {
           context.Remove(reservation);
        }
    }
}