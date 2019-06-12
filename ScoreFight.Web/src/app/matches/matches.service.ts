import { Injectable } from '@angular/core';
import {Observable} from "rxjs/Observable";
import {Http, RequestOptions, Headers} from "@angular/http";
import 'rxjs';

import {Match} from "./models/match";

@Injectable()
export class MatchesService {
  private apiUrl = "https://localhost:44386/api/matches";

  constructor(private http : Http) { }

  getActive() : Observable<Match[]> {
    return this.http.get(this.apiUrl)
      .map((res) => res.json())
  }
}
