using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Core
{
    public interface IParkingLotRepository
    {
        Task<ParkingLot> GetParkingLot(int id); 
        Task<IEnumerable<ParkingLot>> GetParkingLots();
        void Add(ParkingLot parkingLot);
        void Remove(ParkingLot parkingLot);
        //Task<QueryResult<ParkingLot>> GetParkingLot();
    }
}