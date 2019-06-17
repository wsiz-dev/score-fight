using System;

namespace ScoreFight.Domain.Matches.Commands
{
    public class EndMatchCommand : ICommand
    {
        public Guid MatchId { get; set; }

        public MatchResults MatchResult { get; set; }
    }
}
