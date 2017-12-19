using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Core.Models

{
     [Table("Reservations")]
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public DateTime TakeDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        [StringLength(255)]
        public string Name{get;set;}
        [Required]
        [StringLength(255)]
        public string Surname{get;set;}
        [Required]
        [StringLength(255)]
        public string PhoneNumber{get;set;}
        [Required]
        [EmailAddress]
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