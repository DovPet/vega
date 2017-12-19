import { ParkingLot } from './../../models/parkingLot';
import { ParkingLotService } from './../../services/parkingLot.service';
import { Auth } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';


@Component({
    templateUrl: 'parkingLot-list.html'
  })

  export class ParkingLotListComponent implements OnInit {

    parkingLot: ParkingLot[];

    constructor(private parkingLotService: ParkingLotService, private auth: Auth) { }

    ngOnInit() {
        this.parkingLotService.getParkingLots().subscribe(parkingLot => this.parkingLot = parkingLot)
    }
  }