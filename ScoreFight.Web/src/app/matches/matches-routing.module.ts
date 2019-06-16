import {NgModule} from "@angular/core";
import {RouterModule, Route} from "@angular/router";

import {ActiveMatchesListComponent} from "./active-matches-list/active-matches-list.component";
import {MatchDetailsComponent} from "./match-details/match-details.component";

const MATCHES_ROUTES : Route[] = [
  {
    path: 'matches',
    component: ActiveMatchesListComponent
  },
  {
    path: 'matches/:matchId',
    component: MatchDetailsComponent
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
