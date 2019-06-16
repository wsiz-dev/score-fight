using System;

namespace ScoreFight.Domain.Matches.Commands
{
    public class EndMatchCommand : ICommand
    {
        public EndMatchCommand(Guid matchId, MatchResults matchResult)
        {
            MatchId = matchId;
            MatchResult = matchResult;
        }

        public Guid MatchId { get; }

        public MatchResults MatchResult { get; }

    }
}
