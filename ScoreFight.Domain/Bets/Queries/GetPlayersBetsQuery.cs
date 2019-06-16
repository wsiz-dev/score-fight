using System;
using System.Collections.Generic;

namespace ScoreFight.Domain.Bets.Queries
{
    public class GetPlayersBetsQuery : IQuery<ICollection<Bet>>
    {
        public GetPlayersBetsQuery(Guid playerId)
        {
            PlayerId = playerId;    
        }

        public Guid PlayerId { get; }
    }
}