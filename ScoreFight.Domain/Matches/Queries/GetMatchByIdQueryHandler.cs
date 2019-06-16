namespace ScoreFight.Domain.Matches.Queries
{
    internal class GetMatchByIdQueryHandler : IQueryHandler<GetMatchByIdQuery, Match>
    {
        private readonly IMatchesRepository _matchesRepository;

        public GetMatchByIdQueryHandler(IMatchesRepository matchesRepository)
        {
            _matchesRepository = matchesRepository;
        }

        public Match Handle(GetMatchByIdQuery query)
            => _matchesRepository.GetById(query.Id);
    }
}
