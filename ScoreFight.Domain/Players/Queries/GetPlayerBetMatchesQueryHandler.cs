using System.Collections.Generic;
using System.Linq;
using ScoreFight.Domain.Bets;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Players.Queries
{
    public class GetPlayerBetMatchesQueryHandler : IQueryHandler<GetPlayerBetMatchesQuery, ICollection<Match>>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchesRepository _matchesRepository;

        public GetPlayerBetMatchesQueryHandler(IBetRepository betRepository, IMatchesRepository matchesRepository)
        {
            _betRepository = betRepository;
            _matchesRepository = matchesRepository;
        }
        
        public ICollection<Match> Handle(GetPlayerBetMatchesQuery query)
        {
            var matchIds = _betRepository
                .GetBetsByPlayerId(query.PlayerId)
                .Select(x => x.MatchId)
                .ToList();

            var matches = _matchesRepository
                .Query(q => q.Where(match => matchIds.Contains(match.Id)))
                .ToList();

            return matches;
        }
    }
}
