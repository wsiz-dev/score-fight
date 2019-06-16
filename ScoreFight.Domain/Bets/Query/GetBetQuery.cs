using System;

namespace ScoreFight.Domain.Bets.Query
{
    public class GetBetQuery : IQuery<Bet>
    {
        public GetBetQuery(Guid playerId, Guid matchId)
        {
            PlayerId = playerId;
            MatchId = matchId;
        }

        public Guid PlayerId { get; }

        public Guid MatchId { get; }
    }
}
