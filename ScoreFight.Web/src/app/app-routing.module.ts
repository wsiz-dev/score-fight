import {NgModule} from "@angular/core";
import {RouterModule, Route} from "@angular/router";

const APP_ROUTES : Route[] = [
  { path: '', pathMatch: 'full', redirectTo: 'matches' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(APP_ROUTES, {useHash: true})
  ],
  exports: [
    RouterModule
  ]
})

export class AppRoutingModule {}
