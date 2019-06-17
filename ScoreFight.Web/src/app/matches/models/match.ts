import {Bet} from "./bet";

export interface Match {
  id: string;
  homeTeam: string;
  awayTeam: string;
  date: string;
  result: number;
  bets: Bet[];
}
