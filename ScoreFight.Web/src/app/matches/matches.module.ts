import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActiveMatchesListComponent } from './active-matches-list/active-matches-list.component';
import {MatchesService} from "./matches.service";
import {SharedModule} from "../shared-module/shared.module";
import { MatchDetailsComponent } from './match-details/match-details.component';
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule
  ],
  providers: [
    MatchesService
  ],
  declarations: [ActiveMatchesListComponent, MatchDetailsComponent]
})
export class MatchesModule { }
