import {NgModule} from "@angular/core";
import {RouterModule, Route} from "@angular/router";

import {ActiveMatchesListComponent} from "./active-matches-list/active-matches-list.component";

const MATCHES_ROUTES : Route[] = [
  {
    path: 'matches',
    component: ActiveMatchesListComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(MATCHES_ROUTES)
  ],
  exports: [
    RouterModule
  ]
})

export class MatchesRoutingModule {}
