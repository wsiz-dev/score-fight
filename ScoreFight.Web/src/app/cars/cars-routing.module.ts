import {NgModule} from "@angular/core";
import {RouterModule, Route} from "@angular/router";
import {CarDetailsComponent} from "./car-details/car-details.component";
import {CarResolve} from "./car-resolve.service";
import {CarsListComponent} from "./cars-list/cars-list.component";

const CARS_ROUTES : Route[] = [
  {
    path: 'cars',
    component: CarsListComponent
  },
  {
    path: 'cars/:id',
    component: <any>CarDetailsComponent,
    resolve: { car: CarResolve }
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(CARS_ROUTES)
  ],
  exports: [
    RouterModule
  ]
})

export class CarsRoutingModule {}
