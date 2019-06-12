import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyProfileComponent } from './my-profile/my-profile.component';
import {PlayersService} from "./players.service";
import {SharedModule} from "../shared-module/shared.module";
import { RankingComponent } from './ranking/ranking.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  providers: [
    PlayersService
  ],
  declarations: [MyProfileComponent, RankingComponent]
})
export class PlayersModule { }
