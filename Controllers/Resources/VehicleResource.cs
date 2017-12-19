using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using vega.Core.Models;

namespace vega.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public KeyValuePairResource Model { get; set; }
        public KeyValuePairResource Make { get; set; }
        public KeyValuePairResource State { get; set; }
        public bool IsRegistered { get; set; }
        public ContactResource Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LicensePlate { get; set; }
        public string Places { get; set; }         
        public double Cost {get;set;}
        public double Consumption {get;set;}
        public DateTime DateOfManufacture { get; set; }
        public ParkingLot ParkingLot {get;set;}
        public ICollection<KeyValuePairResource> Features { get; set; }
        public ICollection<VehicleResource> Vehicles { get; set; }

        public VehicleResource()
        {
            Features = new Collection<KeyValuePairResource>();
            Vehicles = new Collection<VehicleResource>();
        }        
    }
}