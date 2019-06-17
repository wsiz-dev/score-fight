import { Injectable } from '@angular/core';
import {Observable} from "rxjs/Observable";
import {Http} from "@angular/http";
import 'rxjs';

import {Match} from "./models/match";
import {Bet} from "./models/bet";
import {AuthProvider} from "../shared-module/authProvider";

@Injectable()
export class MatchesService {
  private apiUrl = "https://localhost:44386/api/matches";

  constructor(private http : Http,
              private authProvider: AuthProvider) { }

  getActive() : Observable<Match[]> {
    return this.http.get(this.apiUrl)
      .map((res) => res.json())
  }

  getById(id: string): Observable<Match> {
    return this.http.get(`${this.apiUrl}/${id}`)
      .map((res) => res.json());
  }

  getBets(id: string): Observable<Bet[]> {
    return this.http.get(`${this.apiUrl}/${id}/bets`)
      .map((res) => res.json());
  }

  bet(matchId: string, matchResult: number, points: number): Observable<any> {
    let data = {
      matchId,
      matchResult,
      points,
      playerId: this.authProvider.getUserId()
    };
    return this.http.post(`${this.apiUrl}/${matchId}/bets`, data);
  }
}
