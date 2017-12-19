import { ReservationService } from './../../services/reservation.service';
import { Vehicle } from './../../models/vehicle';
import { Reservation } from './../../models/reservation';
import { Auth } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
    templateUrl: 'reservation-list.html'
  })
  export class ReservationListComponent implements OnInit {
    
    reservation: Reservation[];
    
      constructor(private reservationService: ReservationService, private auth: Auth) { }
      ngOnInit() {
        this.reservationService.getReservations().subscribe(reservation => this.reservation = reservation)
    }

  }