import { ParkingLotService } from './../../services/parkingLot.service';
import { Auth } from './../../services/auth.service';
import { ToastyService } from 'ng2-toasty';
import { Component, OnInit, ElementRef, ViewChild, NgZone } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    templateUrl: 'view-parkingLot.html'
  })
export class ViewParkingLotComponent implements OnInit {
    parkingLot: any;
    parkingLotId: number; 
    constructor(
        private auth: Auth,
        private route: ActivatedRoute, 
        private router: Router,
        private toasty: ToastyService,
        private parkingLotService: ParkingLotService) { 
    
        route.params.subscribe(p => {
          this.parkingLotId = +p['id'];
          if (isNaN(this.parkingLotId) || this.parkingLotId <= 0) {
            router.navigate(['/parkingLot']);
            return; 
          }
        });
      }
    
    ngOnInit() {
        this.parkingLotService.getParkingLot(this.parkingLotId)
        .subscribe(
          v => this.parkingLot = v,
          err => {
            if (err.status == 404) {
              this.router.navigate(['/parkingLot']);
              return; 
            }
          });
    }
    delete() {
        if (confirm("Are you sure?")) {
          this.parkingLotService.delete(this.parkingLot.id)
            .subscribe(x => {
              this.router.navigate(['/parkingLot']);
            });
        }
      }

}