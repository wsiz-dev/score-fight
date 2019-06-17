import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../players.service";
import {Player} from "../models/player";
import {AuthProvider} from "../../shared-module/authProvider";

@Component({
  selector: 'cs-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.less']
})
export class MyProfileComponent implements OnInit {
  player: Player;

  constructor(private playersService: PlayersService,
              private authProvider: AuthProvider) { }

  ngOnInit() {
    this.loadProfile();
  }

  loadProfile(): void {
    this.playersService.getById(this.authProvider.getUserId())
      .subscribe((player) => {
        this.player = player;
      });
  }

}
