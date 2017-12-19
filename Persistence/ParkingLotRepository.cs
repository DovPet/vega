using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Core;
using vega.Core.Models;

namespace vega.Persistence
{
    public class ParkingLotRepository : IParkingLotRepository
    {
    private readonly VegaDbContext context;

    public ParkingLotRepository(VegaDbContext context)
    {
        this.context = context;
    }

        public void Add(ParkingLot parkingLot)
        {
            context.ParkingLot.Add(parkingLot);
        }

        public async Task<ParkingLot> GetParkingLot(int id)
        {
          return await context.ParkingLot.FindAsync(id);
        }

        public void Remove(ParkingLot parkingLot)
        {          
            context.Remove(parkingLot);
        }
        public async Task<IEnumerable<ParkingLot>> GetParkingLots()
        {
            return await context.ParkingLot.ToListAsync();
        }
    }
}