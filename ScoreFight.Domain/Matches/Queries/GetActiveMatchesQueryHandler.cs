using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreFight.Domain.Matches.Queries
{
    internal class GetActiveMatchesQueryHandler : IQueryHandler<GetActiveMatchesQuery, IEnumerable<Match>>
    {
        private readonly IMatchesRepository _matchesRepository;

        public GetActiveMatchesQueryHandler(IMatchesRepository matchesRepository)
        {
            _matchesRepository = matchesRepository;
        }

        public IEnumerable<Match> Handle(GetActiveMatchesQuery query)
        {
            var matches = _matchesRepository
                .Query(q => 
                    q.Where(x => x.Date > DateTime.Now))
                .ToList();

            return matches;
        }
    }
}
