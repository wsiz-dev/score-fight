using System;
using System.Collections.Generic;

namespace ScoreFight.Domain.Bets.Query
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