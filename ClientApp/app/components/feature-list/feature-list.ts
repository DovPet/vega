import { Feature } from './../../models/feature';
import { FeatureService } from './../../services/feature.service';
import { Auth } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';


@Component({
    templateUrl: 'feature-list.html'
  })

  export class FeatureListComponent implements OnInit {

    feature: Feature[];

    constructor(private featureService: FeatureService, private auth: Auth) { }

    ngOnInit() {
        this.featureService.getFeatures().subscribe(feature => this.feature = feature)
    }
  }