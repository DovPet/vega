import { SaveFeature, Feature } from './../../models/feature';
import * as _ from 'underscore'; 
import { Observable } from 'rxjs/Observable';
import { ActivatedRoute, Router } from '@angular/router';
import { FeatureService } from './../../services/feature.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from "ng2-toasty";
import 'rxjs/add/Observable/forkJoin';

@Component({
    selector: 'app-feature-form',
    templateUrl: './feature-form.component.html',
    styleUrls: ['./feature-form.component.css']
  })

  export class FeatureFormComponent implements OnInit {
       
      feature: SaveFeature = {
      id: 0,
      name: ''
    };
    
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private featureService: FeatureService,
        private toastyService: ToastyService) {
    
          route.params.subscribe(p => {
            this.feature.id = +p['id'] || 0;
          });
        }

    ngOnInit()  {   
         if (this.feature.id) {
             this.featureService.getFeature(this.feature.id).subscribe(p=>{this.feature = p;});           
        }
        err => {
          if (err.status == 404)
            this.router.navigate(['/features']);
        };
    }
    private setFeature(p: Feature) {
        this.feature.id = p.id;
        this.feature.name = p.name;
               
      } 

      submit() {
        var result$ = (this.feature.id) ? this.featureService.update(this.feature) : this.featureService.create(this.feature); 
        result$.subscribe(feature => {
          this.toastyService.success({
            title: 'Success', 
            msg: 'Data was sucessfully saved.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
          this.router.navigate(['/features'])
        });
      }
      
      delete() {
        if (confirm("Are you sure?")) {
          this.featureService.delete(this.feature.id)
            .subscribe(x => {
              this.router.navigate(['/features']);
            });
        }
      }
}