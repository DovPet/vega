
import { AdminAuthGuard } from './services/admin-auth-guard.service';
import { AuthGuard } from './services/auth-gaurd.service';
import { AdminComponent } from './components/admin/admin.component';
import { Auth } from './services/auth.service';
import { BrowserXhr } from '@angular/http';
import { BrowserXhrWithProgress, ProgressService } from './services/progress.service';
import { ViewVehicleComponent } from './components/view-vehicle/view-vehicle';
import { PaginationComponent } from './components/shared/pagination.component';
import { VehicleListComponent } from './components/vehicle-list/vehicle-list';
import * as Raven from 'raven-js'; 
import { FormsModule } from '@angular/forms'; 
import { NgModule, ErrorHandler } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';
import { UniversalModule } from 'angular2-universal';
import { ChartModule } from 'angular2-chartjs';

import { AppComponent } from './components/app/app.component'
import { AppErrorHandler } from './app.error-handler';
import { VehicleService } from './services/vehicle.service';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { PhotoService } from "./services/photo.service";
import { AUTH_PROVIDERS } from "angular2-jwt/angular2-jwt";
import { ParkingLotService } from './services/parkingLot.service';
import { ParkingLotFormComponent } from './components/parkingLot-form/parkingLot-form.component';
import { ParkingLotListComponent } from './components/parkingLot-list/parkingLot-list';
import { ViewParkingLotComponent } from './components/view-parkingLot/view-parkingLot';
import { FeatureService } from './services/feature.service';
import { FeatureFormComponent } from './components/feature-form/feature-form.component';
import { FeatureListComponent } from './components/feature-list/feature-list';
import { ReservationService } from './services/reservation.service';
import {ReservationFormComponent } from './components/reservation-form/reservation-form.component';
import {ReservationListComponent } from './components/reservation-list/reservation-list';
import {ViewReservationComponent } from './components/view-reservation/view-reservation';
Raven.config('https://d37bba0c459b46e0857e6e2b3aeff09b@sentry.io/155312').install();

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,

        VehicleFormComponent,
        VehicleListComponent,
        ViewVehicleComponent,

        PaginationComponent,

        ParkingLotFormComponent,
        ParkingLotListComponent,
        ViewParkingLotComponent,

        FeatureFormComponent,
        FeatureListComponent,

        ReservationFormComponent,
        ViewReservationComponent,
        ReservationListComponent,

        AdminComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        ToastyModule.forRoot(),
        ChartModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'vehicles', pathMatch: 'full' },
            { path: 'vehicles/new', component: VehicleFormComponent, canActivate: [ AuthGuard ] },
            { path: 'vehicles/edit/:id', component: VehicleFormComponent, canActivate: [ AuthGuard ] },
            { path: 'vehicles/:id', component: ViewVehicleComponent },
            { path: 'vehicles', component: VehicleListComponent },

            { path: 'parkingLot/new', component: ParkingLotFormComponent, canActivate: [ AuthGuard ] },
            { path: 'parkingLot/edit/:id', component: ParkingLotFormComponent, canActivate: [ AuthGuard ] },
            { path: 'parkingLot/:id', component: ViewParkingLotComponent },
            { path: 'parkingLot', component: ParkingLotListComponent },

            { path: 'features/new', component: FeatureFormComponent, canActivate: [ AuthGuard ] },
            { path: 'features/edit/:id', component: FeatureFormComponent, canActivate: [ AuthGuard ] },
            { path: 'features', component: FeatureListComponent },

            { path: 'reservations/new', component: ReservationFormComponent, canActivate: [ AuthGuard ] },
            { path: 'reservations/edit/:id', component: ReservationFormComponent, canActivate: [ AuthGuard ] },
            { path: 'reservations/:id', component: ViewReservationComponent },
            { path: 'reservations', component: ReservationListComponent },

            { path: 'admin', component: AdminComponent, canActivate: [ AdminAuthGuard ] },
            { path: 'home', component: HomeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
      { provide: ErrorHandler, useClass: AppErrorHandler },
      Auth,
      AuthGuard,
      AUTH_PROVIDERS,
      AdminAuthGuard,
      VehicleService,
      PhotoService,
      ParkingLotService,
      FeatureService,
      ReservationService
    ]
})
export class AppModule {
}
