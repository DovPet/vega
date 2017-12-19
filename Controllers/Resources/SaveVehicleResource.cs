using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace vega.Controllers.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int StateId { get; set; }
        public int ParkingLotId { get; set; }
        public bool IsRegistered { get; set; }
        public string LicensePlate { get; set; }
        public string Places { get; set; }         
        public double Cost {get;set;}
        public double Consumption {get;set;}
        public DateTime DateOfManufacture { get; set; }
        [Required]
        public ContactResource Contact { get; set; }
        //public ParkingLotResource ParkingLot { get; set; }
        public ICollection<int> Features { get; set; }

        public SaveVehicleResource()
        {
            Features = new Collection<int>();
        }
    }
}