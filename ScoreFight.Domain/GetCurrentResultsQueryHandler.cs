using System.Collections.Generic;
using System.Linq;

namespace ScoreFight.Domain
{
    internal class GetCurrentResultsQueryHandler : IQueryHandler<GetCurrentResultsQuery, IEnumerable<Team>>
    {
        private readonly IFootballRepository _repository;

        public GetCurrentResultsQueryHandler(IFootballRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Team> Handle(GetCurrentResultsQuery query)
        {
            var result = _repository.Query(q => q
                    .OrderByDescending(x => x.Points)
                    .ThenByDescending(x => x.GoalsBalance))
                .ToList();

            return result;
        }
    }
}
