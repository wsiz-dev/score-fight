using System;

namespace ScoreFight.Domain.Matches.Command
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
