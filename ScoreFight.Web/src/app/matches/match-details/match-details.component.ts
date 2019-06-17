import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Match} from "../models/match";
import {MatchesService} from "../matches.service";
import {BetPoints} from "../models/betPoints";

@Component({
  selector: 'cs-match-details',
  templateUrl: './match-details.component.html',
  styleUrls: ['./match-details.component.less']
})
export class MatchDetailsComponent implements OnInit {
  private match: Match;
  private myBet: number;
  private points: number;
  private betPoints: BetPoints;
  private errorMessage: string;

  constructor(private route: ActivatedRoute,
              private matchesService: MatchesService) {
    this.betPoints = new BetPoints();
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('matchId');
    this.loadMatch(id);
    this.myBet = 0;
    this.points = 0;
  }

  loadMatch(id: string): void {
    this.matchesService.getById(id)
      .subscribe((match) => {
        this.matchesService.getBets(id)
          .subscribe((bets) => {
            this.match = {...match, bets};
            this.betPoints = {
              homeTeam: this.calculatePointsForTeam(1),
              awayTeam: this.calculatePointsForTeam(2),
              draw: this.calculatePointsForTeam(3)
            };
          });
      });
  }

  selectTeam(bet: number): void {
    this.myBet = bet;
    if (bet == 0) {
      this.errorMessage = '';
    }
  }

  getMyBetText(): string {
    switch (this.myBet) {
      case 1: return this.match.homeTeam;
      case 2: return this.match.awayTeam;
      case 3: return 'DRAW';
      default: return '';
    }
  }

  bet(): void {
    if (this.myBet === 0) {
      this.errorMessage = 'Bet must be chosen';
      return;
    } else if (this.points < 1) {
      this.errorMessage = 'Insert bet points value greater than 0';
      return;
    }

    this.errorMessage = '';
    this.matchesService.bet(this.match.id, this.myBet, this.points)
      .subscribe(() => {
        this.myBet = 0;
        this.points = 0;
        this.loadMatch(this.match.id);
      }, error => {
        this.errorMessage = error.json().Message;
      });
  }

  private calculatePointsForTeam(matchResult: number): number {
    let points = 0;
    this.match.bets
      .filter(x => x.matchResult === matchResult)
      .forEach(bet => points += bet.points);

    return points;
  }
}
