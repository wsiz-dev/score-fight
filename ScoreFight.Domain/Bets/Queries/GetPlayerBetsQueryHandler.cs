using System.Collections.Generic;

namespace ScoreFight.Domain.Bets.Queries
{
    public class GetPlayerBetsQueryHandler : IQueryHandler<GetPlayersBetsQuery, ICollection<Bet>>
    {
        private readonly IBetRepository _betRepository;

        public GetPlayerBetsQueryHandler(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }
        
        public ICollection<Bet> Handle(GetPlayersBetsQuery query)
        {
            return _betRepository.GetBetsByPlayerId(query.PlayerId);
        }
    }
}
