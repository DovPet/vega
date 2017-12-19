using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Core
{
    public interface IReservationRepository
    {
        Task<Reservation> GetReservation(int id); 
        Task<IEnumerable<Reservation>> GetReservations();
        void Add(Reservation reservation);
        void Remove(Reservation reservation);

    }
}