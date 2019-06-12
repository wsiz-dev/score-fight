import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../players.service";
import {RankingPosition} from "../models/rankingPosition";

@Component({
  selector: 'cs-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.less']
})
export class RankingComponent implements OnInit {
  positions: RankingPosition[] = [];

  constructor(private playersService: PlayersService) { }

  ngOnInit() {
    this.loadPositions();
  }

  loadPositions(): void {
    this.playersService.getRanking()
      .subscribe((positions) => {
        this.positions = positions;
      });
  }
}
