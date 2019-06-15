using System;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Bets
{
    public class Bet
    {
        public Bet(Guid playerId, Guid matchId, MatchResults matchResults, int points)
        {
            PlayerId = playerId;
            MatchId = matchId;
            MatchResults = matchResults;
            Points = points;
        }
        public Player Player { get; protected set; }

        public Guid PlayerId { get; protected set; }

        public Match Match { get; protected set; }

        public Guid MatchId { get; protected set; }

        public MatchResults MatchResults { get; protected set; }

        public int Points { get; protected set; }

        public void SetMatchResult(int matchResults)
        {
            MatchResults = (MatchResults)matchResults;
        }

        public void SetPointsBet(int pointsBet)
        {
            Points = pointsBet;
        }
    }
}
