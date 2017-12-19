import { SaveParkingLot } from './../models/parkingLot';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';
import { AuthHttp } from "angular2-jwt/angular2-jwt";

@Injectable()
export class ParkingLotService {
  private readonly parkingLotsEndpoint = '/api/parkingLot';

  constructor(private http: Http, private authHttp: AuthHttp) { }

  create(parkingLot) {
    return this.authHttp.post(this.parkingLotsEndpoint, parkingLot)
      .map(res => res.json());
  }

  getParkingLot(id) {
    return this.http.get(this.parkingLotsEndpoint + '/' + id)
      .map(res => res.json());
  }
  getParkingLots() {
    return this.http.get(this.parkingLotsEndpoint)
      .map(res => res.json());
  }
  update(parkingLot: SaveParkingLot) {
    return this.authHttp.put(this.parkingLotsEndpoint + '/' + parkingLot.id, parkingLot)
      .map(res => res.json());
  }

  delete(id) {
    return this.authHttp.delete(this.parkingLotsEndpoint + '/' + id)
      .map(res => res.json());
  }
}