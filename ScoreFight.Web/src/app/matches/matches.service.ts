import { Injectable } from '@angular/core';
import {Observable} from "rxjs/Observable";
import {Http} from "@angular/http";
import 'rxjs';

import {Match} from "./models/match";
import {Bet} from "./models/bet";

@Injectable()
export class MatchesService {
  private apiUrl = "https://localhost:44386/api/matches";

  constructor(private http : Http) { }

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

  end(matchId: string, matchResult: number): Observable<any> {
    const data = {
      matchId,
      matchResult
    };
    return this.http.put(this.apiUrl, data);
  }

  bet(bet: Bet): Observable<any> {
    return this.http.post(`${this.apiUrl}/${bet.matchId}/bets`, bet);
  }

  cancelBet(bet: Bet): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${bet.matchId}/bets/${bet.playerId}`);
  }
}
