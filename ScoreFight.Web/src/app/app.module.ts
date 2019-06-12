import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import {CarsModule} from "./cars/cars.module";
import {CarsService} from "./cars/cars.service";
import {CoreModule} from "./core-module/core.module";
import {AppRoutingModule} from "./app-routing.module";
import {CarsRoutingModule} from "./cars/cars-routing.module";
import {MatchesModule} from "./matches/matches.module";
import {MatchesRoutingModule} from "./matches/matches-routing.module";
import {PlayersRoutingModule} from "./players/players-routing.module";
import {PlayersModule} from "./players/players.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    CarsModule,
    CoreModule,
    MatchesModule,
    PlayersModule,
    AppRoutingModule,
    CarsRoutingModule,
    MatchesRoutingModule,
    PlayersRoutingModule
  ],
  providers: [CarsService],
  bootstrap: [AppComponent]
})

export class AppModule {}

