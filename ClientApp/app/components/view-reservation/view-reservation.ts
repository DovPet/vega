import { ReservationService } from './../../services/reservation.service';
import { Auth } from './../../services/auth.service';
import { BrowserXhr } from '@angular/http';
import { ToastyService } from 'ng2-toasty';
import { Component, OnInit, ElementRef, ViewChild, NgZone } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    templateUrl: 'view-reservation.html'
  })
  export class ViewReservationComponent implements OnInit {
    reservation: any;
    reservationId: number; 
    constructor(
        private auth: Auth,
        private route: ActivatedRoute, 
        private router: Router,
        private toasty: ToastyService,
        private reservationService: ReservationService) { 
    
        route.params.subscribe(p => {
          this.reservationId = +p['id'];
          if (isNaN(this.reservationId) || this.reservationId <= 0) {
            router.navigate(['/reservations']);
            return; 
          }
        });
      }

      ngOnInit() {
        this.reservationService.getReservation(this.reservationId)
        .subscribe(
          v => this.reservation = v,
          err => {
            if (err.status == 404) {
              this.router.navigate(['/reservations']);
              return; 
            }
          });
    }
    delete() {
        if (confirm("Are you sure?")) {
          this.reservationService.delete(this.reservation.id)
            .subscribe(x => {
              this.router.navigate(['/reservations']);
            });
        }
      }
}