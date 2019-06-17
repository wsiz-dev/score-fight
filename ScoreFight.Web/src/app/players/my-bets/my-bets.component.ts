import { Component, OnInit } from '@angular/core';
import {Match} from "../../matches/models/match";
import {Router} from "@angular/router";
import {AuthProvider} from "../../shared-module/authProvider";
import {PlayersService} from "../players.service";

@Component({
  selector: 'cs-my-bets',
  templateUrl: './my-bets.component.html',
  styleUrls: ['./my-bets.component.less']
})
export class MyBetsComponent implements OnInit {
  matches : Match[] = [];

  constructor(private playerService: PlayersService,
              private router: Router,
              private authProvider: AuthProvider) {}

  ngOnInit() {
    this.loadMatches();
  }

  loadMatches() : void {
    this.playerService.getBetMatches(this.authProvider.getUserId())
      .subscribe((matches) => {
        this.matches = matches;
      });
  }

  goToMatch(match: Match): void {
    this.router.navigate(['/matches', match.id]);
  }
}
