import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActiveMatchesListComponent } from './active-matches-list/active-matches-list.component';
import {MatchesService} from "./matches.service";
import {SharedModule} from "../shared-module/shared.module";

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  providers: [
    MatchesService
  ],
  declarations: [ActiveMatchesListComponent]
})
export class MatchesModule { }
