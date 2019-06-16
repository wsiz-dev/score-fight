namespace ScoreFight.Domain.Bets.Queries
{
    public class GetBetQueryHandler : IQueryHandler<GetBetQuery, Bet>
    {
        private readonly IBetRepository _betRepository;

        public GetBetQueryHandler(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }
        public Bet Handle(GetBetQuery query)
        {
            return _betRepository.GetPlayerBet(query.PlayerId, query.MatchId);
        }
    }
}
