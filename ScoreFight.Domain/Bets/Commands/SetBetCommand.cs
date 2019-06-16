using System;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Bets.Commands
{
    public class SetBetCommand : ICommand
    {
        public Guid PlayerId { get; set; }

        public Guid MatchId { get; set; }

        public MatchResults TeamBet { get; set; }

        public int PointsBet { get; set; }
    }
}
