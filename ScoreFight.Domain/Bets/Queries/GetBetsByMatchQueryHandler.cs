using System.Collections.Generic;

namespace ScoreFight.Domain.Bets.Queries
{
    internal class GetBetsByMatchQueryHandler : IQueryHandler<GetBetsByMatchQuery, IEnumerable<Bet>>
    {
        private readonly IBetRepository _betRepository;

        public GetBetsByMatchQueryHandler(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        public IEnumerable<Bet> Handle(GetBetsByMatchQuery query) 
            => _betRepository.GetBetsByMatchId(query.MatchId);
    }
}
