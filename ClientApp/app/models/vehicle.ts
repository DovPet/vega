import { ParkingLot } from './parkingLot';
import { Contact, KeyValuePair } from './vehicle';

export interface KeyValuePair { 
  id: number; 
  name: string; 
}

export interface Contact {
  name: string;
  phone: string;
  email: string;
}

export interface Vehicle {
  id: number; 
  model: KeyValuePair;
  make: KeyValuePair;
  state: KeyValuePair;
  isRegistered: boolean;
  features: KeyValuePair[];
  contact: Contact;
  parkingLot: ParkingLot;
  lastUpdate: string; 
  licensePlate: string;
  places: string;
  cost: number;
  consumption: number;
  dateOfManufacture: Date;
}

export interface SaveVehicle {
  id: number; 
  modelId: number;
  makeId: number;
  stateId: number;
  parkingLotId: number;
  isRegistered: boolean;
  licensePlate: string;
  places: string;
  cost: number;
  consumption: number;
  dateOfManufacture: Date;
  features: number[];
  contact: Contact;
}