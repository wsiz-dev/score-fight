import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Match} from "../models/match";
import {MatchesService} from "../matches.service";
import {BetPoints} from "../models/betPoints";
import {Bet} from "../models/bet";
import {AuthProvider} from "../../shared-module/authProvider";

@Component({
  selector: 'cs-match-details',
  templateUrl: './match-details.component.html',
  styleUrls: ['./match-details.component.less']
})
export class MatchDetailsComponent implements OnInit {
  private match: Match;
  private myBet: Bet;
  private betPoints: BetPoints;
  private errorMessage: string;
  private readonly playerId: string;
  private endMatchResult: number;

  constructor(private route: ActivatedRoute,
              private matchesService: MatchesService,
              private authProvider: AuthProvider) {
    this.betPoints = new BetPoints();
    this.playerId = this.authProvider.getUserId().toLowerCase();
    this.endMatchResult = 0;
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('matchId');
    this.loadMatch(id);
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

            this.myBet = this.match.bets.find(x => x.playerId === this.playerId);
          });
      });
  }

  selectTeam(bet: number): void {
    if (!this.myBet){
      this.myBet = {
        playerId: this.playerId,
        matchResult: bet,
        points: 0,
        matchId: this.match.id
      };
    } else {
      this.myBet.matchResult = bet;
    }
  }

  reset(): void {
    this.myBet.matchResult = 0;
    this.myBet.points = 0;
    this.errorMessage = '';
  }

  cancel(): void {
    this.matchesService.cancelBet(this.myBet)
      .subscribe(() => {
        this.myBet = null;
        this.loadMatch(this.match.id);
      }, error => {
        this.errorMessage = error.json().Message;
      });
  }

  bet(): void {
    if (this.myBet.points === 0) {
      this.errorMessage = 'Bet must be chosen';
      return;
    } else if (this.myBet.points < 1) {
      this.errorMessage = 'Insert bet points value greater than 0';
      return;
    }

    this.errorMessage = '';
    this.matchesService.bet(this.myBet)
      .subscribe(() => {
        this.loadMatch(this.match.id);
      }, error => {
        this.errorMessage = error.json().Message;
      });
  }

  end(): void {
    if (this.endMatchResult < 1) {
      return;
    }

    this.matchesService.end(this.match.id, this.endMatchResult)
      .subscribe(() => {
        this.loadMatch(this.match.id);
      });
  }

  getMyBetText(): string {
    return this.getTextByBet(this.myBet.matchResult);
  }

  getTextByBet(matchResult: number): string {
    switch (matchResult) {
      case 1: return this.match.homeTeam;
      case 2: return this.match.awayTeam;
      case 3: return 'DRAW';
      default: return '';
    }
  }

  private calculatePointsForTeam(matchResult: number): number {
    let points = 0;
    this.match.bets
      .filter(x => x.matchResult === matchResult)
      .forEach(bet => points += bet.points);

    return points;
  }
}
