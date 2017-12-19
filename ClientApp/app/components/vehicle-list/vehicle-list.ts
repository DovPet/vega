import { Auth } from './../../services/auth.service';
import { Vehicle, KeyValuePair } from './../../models/vehicle';
import { ParkingLot } from './../../models/parkingLot';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: 'vehicle-list.html'
})
export class VehicleListComponent implements OnInit {
  private readonly PAGE_SIZE = 10; 

  queryResult: any = {};
  makes: KeyValuePair[];
  state: KeyValuePair[];
  parkingLots: ParkingLot[];
  query: any = {
    pageSize: this.PAGE_SIZE
  };
  columns = [
    { title: 'Id' },
    { title: 'Contact Name', key: 'contactName', isSortable: true },
    { title: 'Make', key: 'make', isSortable: true },
    { title: 'Model', key: 'model', isSortable: true },
    { title: 'State', key: 'state', isSortable: true },
    { title: 'ParkingLot', key: 'parkinglot', isSortable: true },
    { }
  ];

  constructor(private vehicleService: VehicleService, private auth: Auth) { }

  ngOnInit() { 
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes);
    this.vehicleService.getStates()
      .subscribe(state => this.state = state);
      this.vehicleService.getParkingLots()
      .subscribe(parkingLot => this.parkingLots = parkingLot);

    this.populateVehicles();
  }

  private populateVehicles() {
    this.vehicleService.getVehicles(this.query)
      .subscribe(result => this.queryResult = result);
  }

  onFilterChange() {
    this.query.page = 1; 
    this.populateVehicles();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateVehicles();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending; 
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateVehicles();
  }

  onPageChange(page) {
    this.query.page = page; 
    this.populateVehicles();
  }
}