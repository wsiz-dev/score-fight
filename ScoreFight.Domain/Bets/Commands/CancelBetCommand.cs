using System;

namespace ScoreFight.Domain.Bets.Commands
{
    public class CancelBetCommand : ICommand
    {
        public Guid PlayerId { get; set; }

        public Guid MatchId { get; set; }
    }
}
