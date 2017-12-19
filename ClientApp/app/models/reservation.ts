import {Vehicle } from './vehicle';
import {ParkingLot } from './parkingLot';

export interface Reservation {
    id: number;
    takeDate: Date;
    returnDate: Date; 
    name: string; 
    surname: string;
    phoneNumber: string;
    email: string;
    vehicle: Vehicle;
    parkingLot: ParkingLot;
    finished: boolean;
    fuel: string;
    washed: boolean;
    comment: string;
    
  }
  
  export interface SaveReservation {
    id: number;
    takeDate: Date;
    returnDate: Date; 
    name: string; 
    surname: string;
    phoneNumber: string;
    email: string;
    vehicleId: number;
    parkingLotId: number;
    finished: boolean;
    fuel: string;
    washed: boolean;
    comment: string;
  }
