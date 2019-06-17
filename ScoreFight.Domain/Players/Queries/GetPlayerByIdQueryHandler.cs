namespace ScoreFight.Domain.Players.Queries
{
    internal class GetPlayerByIdQueryHandler : IQueryHandler<GetPlayerByIdQuery, Player>
    {
        private readonly IPlayersRepository _playersRepository;

        public GetPlayerByIdQueryHandler(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        public Player Handle(GetPlayerByIdQuery query)
            => _playersRepository.GetById(query.Id);
    }
}
