import { Component, OnInit} from '@angular/core';
import {Match} from "../models/match";
import {MatchesService} from "../matches.service";
import {Router} from "@angular/router";

@Component({
  selector: 'cs-active-matches-list',
  templateUrl: './active-matches-list.component.html',
  styleUrls: ['./active-matches-list.component.less']
})
export class ActiveMatchesListComponent implements OnInit {
  matches : Match[] = [];

  constructor(private matchesService: MatchesService,
              private router: Router) {}

  ngOnInit() {
    this.loadMatches();
  }

  loadMatches() : void {
    this.matchesService.getActive().subscribe((matches) => {
      this.matches = matches;
    });
  }

  goToMatch(match: Match): void {
    this.router.navigate(['/matches', match.id]);
  }
}
