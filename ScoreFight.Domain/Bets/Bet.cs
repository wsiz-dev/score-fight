using System;
using ScoreFight.Domain.Bets.Enums;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Bets
{
    public class Bet
    {
        public Bet(Guid playerId, Guid matchId, TeamBet teamBet, int points)
        {
            PlayerId = playerId;
            MatchId = matchId;
            TeamBet = teamBet;
            Points = points;
        }
        public Player Players { get; protected set; }

        public Guid PlayerId { get; protected set; }

        public Match Matches { get; protected set; }

        public Guid MatchId { get; protected set; }

        public TeamBet TeamBet { get; protected set; }

        public int Points { get; protected set; }

        public void SetTeamBet(int teamBet)
        {
            TeamBet = (TeamBet)teamBet;
        }

        public void SetPointsBet(int pointsBet)
        {
            Points = pointsBet;
        }

    }
}
