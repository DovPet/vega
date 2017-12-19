using System;
using vega.Core.Models;

namespace vega.Controllers.Resources
{
    public class ReservationResource
    {
        public int Id { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Name{get;set;}
        public string Surname{get;set;}
        public string PhoneNumber{get;set;}
        public string Email{get;set;}
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; }
        
        public bool Finished{get;set;}
        public string Fuel{get;set;}
        public bool Washed{get;set;}
        public string Comment{get;set;}
    }
}