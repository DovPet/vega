import * as _ from 'underscore'; 
import { SaveVehicle, Vehicle } from './../../models/vehicle';
import { Observable } from 'rxjs/Observable';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from "ng2-toasty";
import 'rxjs/add/Observable/forkJoin';
import { addToArray } from '@angular/core/src/linker/view_utils';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[]; 
  models: any[];
  features: any[];
  states: any[];
  parkingLots: any[];
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    stateId: 0,
    parkingLotId: 0,
    licensePlate: '',
    places: '',
    cost: 0,
    consumption: 0,
    dateOfManufacture: null,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      email: '',
      phone: '',
    }
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    private toastyService: ToastyService) {

      route.params.subscribe(p => {
        this.vehicle.id = +p['id'] || 0;
      });
    }

  ngOnInit() {
    var sources = [

      this.vehicleService.getMakes(),
      this.vehicleService.getStates(),
      this.vehicleService.getFeatures(),
      this.vehicleService.getParkingLots()
    ];

    if (this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));

    Observable.forkJoin(sources).subscribe(data => {
      this.makes = data[0];
      this.states = data[1];
      this.features = data[2];
      this.parkingLots = data[3];
      if (this.vehicle.id) {
        this.setVehicle(data[4]);
        this.populateModels();
      }
    }, err => {
      if (err.status == 404)
        this.router.navigate(['/home']);
    });
  }

  private setVehicle(v: Vehicle) {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.stateId = v.state.id;
    this.vehicle.parkingLotId = v.parkingLot.id;
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.licensePlate = v.licensePlate;
    this.vehicle.places = v.places;
    this.vehicle.cost = v.cost;
    this.vehicle.consumption = v.consumption;
    this.vehicle.dateOfManufacture = v.dateOfManufacture;
    this.vehicle.contact = v.contact;
    this.vehicle.features = _.pluck(v.features, 'id');
  } 

  onMakeChange() {
    this.populateModels();

    delete this.vehicle.modelId;
  }

  private populateModels() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    var result$ = (this.vehicle.id) ? this.vehicleService.update(this.vehicle) : this.vehicleService.create(this.vehicle); 
    result$.subscribe(vehicle => {
      this.toastyService.success({
        title: 'Success', 
        msg: 'Data was sucessfully saveds.',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
      this.router.navigate(['/vehicles/', vehicle.id])
    });
  } 
}
