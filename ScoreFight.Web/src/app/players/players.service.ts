import { Injectable } from '@angular/core';
import {Http} from "@angular/http";
import {Observable} from "rxjs";
import {Player} from "./models/player";

@Injectable()
export class PlayersService {
  private apiUrl = "https://localhost:44386/api/players";

  constructor(private http : Http) { }

  getById(id: string) : Observable<Player> {
    return this.http.get(`${this.apiUrl}/${id}`)
      .map((res) => res.json())
  }
}
