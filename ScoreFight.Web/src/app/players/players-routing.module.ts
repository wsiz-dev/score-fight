import {NgModule} from "@angular/core";
import {RouterModule, Route} from "@angular/router";

import {MyProfileComponent} from "./my-profile/my-profile.component";
import {RankingComponent} from "./ranking/ranking.component";

const MATCHES_ROUTES : Route[] = [
  {
    path: 'my-profile',
    component: MyProfileComponent
  },
  {
    path: 'ranking',
    component: RankingComponent
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

export class PlayersRoutingModule {}
