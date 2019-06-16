using System;
using System.Collections.Generic;

namespace ScoreFight.Domain.Bets.Queries
{
    public class GetBetsByMatchQuery : IQuery<IEnumerable<Bet>>
    {
        public Guid MatchId { get; set; }
    }
}
