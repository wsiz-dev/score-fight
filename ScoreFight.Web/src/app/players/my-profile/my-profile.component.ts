import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../players.service";
import {Player} from "../models/player";

@Component({
  selector: 'cs-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.less']
})
export class MyProfileComponent implements OnInit {
  private readonly myHarcodedTemporaryIdFromApi: string = "C9888D13-E9DA-454A-86A2-62BEC0302F2D";
  player: Player;

  constructor(private playersService: PlayersService) { }

  ngOnInit() {
    this.loadProfile();
  }

  loadProfile(): void {
    this.playersService.getById(this.myHarcodedTemporaryIdFromApi)
      .subscribe((player) => {
        this.player = player;
      });
  }

}
