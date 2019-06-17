using System;
using System.Collections.Generic;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Players.Queries
{
    public class GetPlayerBetMatchesQuery : IQuery<ICollection<Match>>
    {
        public Guid PlayerId { get; set; }
    }
}