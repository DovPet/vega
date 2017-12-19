using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Controllers.Resources
{
    public class ParkingLotResource
    {
        public int Id { get; set; }   
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<ParkingLotResource> ParkingLots { get; set; }

        public ParkingLotResource()
        {
            ParkingLots = new Collection<ParkingLotResource>();
        }
    }
}