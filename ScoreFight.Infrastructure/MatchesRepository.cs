using System;
using System.Collections.Generic;
using System.Linq;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Infrastructure
{
    internal class MatchesRepository : IMatchesRepository
    {
        private readonly EfContext _efContext;

        public MatchesRepository(EfContext efContext)
        {
            _efContext = efContext;
        }

        public IEnumerable<Match> Query(Func<IQueryable<Match>, IEnumerable<Match>> query)
            => query(_efContext.Matches).ToList();
    }
}
