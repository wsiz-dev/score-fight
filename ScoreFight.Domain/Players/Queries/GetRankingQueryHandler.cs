using System.Collections.Generic;
using System.Linq;

namespace ScoreFight.Domain.Players.Queries
{
    internal class GetRankingQueryHandler : IQueryHandler<GetRankingQuery, IEnumerable<RankingPosition>>
    {
        private readonly IPlayersRepository _playersRepository;

        public GetRankingQueryHandler(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        public IEnumerable<RankingPosition> Handle(GetRankingQuery query)
        {
            var players = _playersRepository
                .Query(q => q.OrderByDescending(x => x.Points))
                .ToList();

            var orderNumber = 1;
            return players
                .Select(player => new RankingPosition(orderNumber++, player))
                .ToList();
        }
    }
}
