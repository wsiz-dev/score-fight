import {NgModule} from "@angular/core";
import {RouterModule, Route} from "@angular/router";

import {MyProfileComponent} from "./my-profile/my-profile.component";

const MATCHES_ROUTES : Route[] = [
  {
    path: 'my-profile',
    component: MyProfileComponent
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
