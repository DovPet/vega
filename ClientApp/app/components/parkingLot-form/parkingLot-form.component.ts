import { SaveParkingLot,ParkingLot} from './../../models/parkingLot';
import * as _ from 'underscore'; 
import { Observable } from 'rxjs/Observable';
import { ActivatedRoute, Router } from '@angular/router';
import { ParkingLotService } from './../../services/parkingLot.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from "ng2-toasty";
import 'rxjs/add/Observable/forkJoin';

@Component({
    selector: 'app-parkingLot-form',
    templateUrl: './parkingLot-form.component.html',
    styleUrls: ['./parkingLot-form.component.css']
  })

  export class ParkingLotFormComponent implements OnInit {
    
    parkingLot: SaveParkingLot = {
      id: 0,
      name: '',
      address: ''
    };

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private parkingLotService: ParkingLotService,
        private toastyService: ToastyService) {
    
          route.params.subscribe(p => {
            this.parkingLot.id = +p['id'] || 0;
          });
        }

    ngOnInit()  {

           
            if (this.parkingLot.id) {
                this.parkingLotService.getParkingLot(this.parkingLot.id).subscribe(p=>{this.parkingLot = p;});
              
            
        }
        err => {
          if (err.status == 404)
            this.router.navigate(['/home']);
        };
    }

    private setParkingLot(p: ParkingLot) {
        this.parkingLot.id = p.id;
        this.parkingLot.name = p.name;
        this.parkingLot.address = p.address;
        
      } 

      submit() {
        var result$ = (this.parkingLot.id) ? this.parkingLotService.update(this.parkingLot) : this.parkingLotService.create(this.parkingLot); 
        result$.subscribe(parkingLot => {
          this.toastyService.success({
            title: 'Success', 
            msg: 'Data was sucessfully saveds.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
          this.router.navigate(['/parkingLot/', parkingLot.id])
        });
      }
}