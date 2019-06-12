using System;
using ScoreFight.Domain.Bets.Enums;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Bets
{
    public class Bet
    {
        public Bet(Guid userId, Guid matchId, TeamBet teamBet, int points)
        {
            UserId = userId;
            MatchId = matchId;
            TeamBet = teamBet;
            Points = points;
        }
        public User Users { get; protected set; }

        public Guid UserId { get; protected set; }

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
