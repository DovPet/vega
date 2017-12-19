import * as _ from 'underscore'; 
import { Observable } from 'rxjs/Observable';
import { ReservationService } from './../../services/reservation.service';
import { SaveReservation, Reservation } from './../../models/reservation';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from "ng2-toasty";
import 'rxjs/add/Observable/forkJoin';

@Component({
    selector: 'app-reservation-form',
    templateUrl: './reservation-form.component.html',
    styleUrls: ['./reservation-form.component.css']
  })
  export class ReservationFormComponent implements OnInit {
    vehicles: any = {};
    parkingLots: any[];
    reservation: SaveReservation = {
        id: 0,
        takeDate: null,
        returnDate: null, 
        name: '',
        surname: '',
        phoneNumber: '',
        email: '',
        vehicleId: 0,
        parkingLotId: 0,
        finished: false,
        fuel: '',
        washed: false,
        comment: '',
    };
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private reservationService: ReservationService,
        private toastyService: ToastyService) {
    
          route.params.subscribe(p => {
            this.reservation.id = +p['id'] || 0;
          });
        }
       
  ngOnInit() {
    var sources = [
      this.reservationService.getVehicles(),
      this.reservationService.getParkingLots()
    ];

    if (this.reservation.id)
      sources.push(this.reservationService.getReservation(this.reservation.id));

    Observable.forkJoin(sources).subscribe(data => {
      this.vehicles = data[0];
      this.parkingLots = data[1];
      if (this.reservation.id) {
        this.setReservation(data[2]);
       
      }
    }, err => {
      if (err.status == 404)
        this.router.navigate(['/home']);
    });
  }
  
  
  private setReservation(r: Reservation) {
    this.reservation.id = r.id;
    this.reservation.takeDate = r.takeDate;
    this.reservation.returnDate = r.returnDate;
    this.reservation.name = r.name;
    this.reservation.surname = r.surname;
    this.reservation.phoneNumber=r.phoneNumber;
    this.reservation.email=r.email;
    this.reservation.vehicleId=r.vehicle.id;
    this.reservation.parkingLotId=r.parkingLot.id;
    this.reservation.finished=r.finished;
    this.reservation.fuel=r.fuel;
    this.reservation.washed=r.washed;
    this.reservation.comment=r.comment;
  } 
  
  submit() {
    var result$ = (this.reservation.id) ? this.reservationService.update(this.reservation) : this.reservationService.create(this.reservation); 
    result$.subscribe(reservation => {
      this.toastyService.success({
        title: 'Success', 
        msg: 'Data was sucessfully saveds.',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
      this.router.navigate(['/reservations/'])
    });
  }
}