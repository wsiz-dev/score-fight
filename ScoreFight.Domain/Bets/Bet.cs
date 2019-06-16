using System;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Bets
{
    public class Bet
    {
        public Guid PlayerId { get; set; }

        public Guid MatchId { get; set; }

        public MatchResults MatchResults { get; set; }

        public int Points { get; set; }
    }
}
