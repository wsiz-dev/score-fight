import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Match} from "../models/match";
import {MatchesService} from "../matches.service";

@Component({
  selector: 'cs-match-details',
  templateUrl: './match-details.component.html',
  styleUrls: ['./match-details.component.less']
})
export class MatchDetailsComponent implements OnInit {
  private match: Match;
  private myBet: number;

  constructor(private route: ActivatedRoute,
              private matchesService: MatchesService) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('matchId');
    this.loadMatch(id);
    this.myBet = 0;
  }

  loadMatch(id: string): void {
    this.matchesService.getById(id)
      .subscribe((match) => {
        this.match = match;
      });
  }

  selectTeam(bet: number): void {
    this.myBet = bet;
    event.stopPropagation();
  }

  getMyBetText(): string {
    switch (this.myBet) {
      case 1: return this.match.homeTeam;
      case 2: return this.match.awayTeam;
      case 3: return 'DRAW';
      default: return '';
    }
  }
}
