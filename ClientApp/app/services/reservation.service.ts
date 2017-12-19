import { SaveReservation } from './../models/reservation';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';
import { AuthHttp } from "angular2-jwt/angular2-jwt";
import { addToArray } from '@angular/core/src/linker/view_utils';

@Injectable()
export class ReservationService {
  private readonly reservationEndpoint = '/api/reservations';

  constructor(private http: Http, private authHttp: AuthHttp) { }

  getParkingLots() {
    return this.http.get('/api/parkingLot')
      .map(res => res.json());
  }

  getVehicles() {
    return this.http.get('/api/vehicles')
      .map(res => res.json());
  }
  create(reservation) {
    return this.authHttp.post(this.reservationEndpoint, reservation)
      .map(res => res.json());
  }

  getReservation(id) {
    return this.http.get(this.reservationEndpoint + '/' + id)
      .map(res => res.json());
  }
  getReservations() {
    return this.http.get(this.reservationEndpoint)
      .map(res => res.json());
  }
 
  update(reservation: SaveReservation) {
    return this.authHttp.put(this.reservationEndpoint + '/' + reservation.id, reservation)
      .map(res => res.json());
  }

  delete(id) {
    return this.authHttp.delete(this.reservationEndpoint + '/' + id)
      .map(res => res.json());
  }
}