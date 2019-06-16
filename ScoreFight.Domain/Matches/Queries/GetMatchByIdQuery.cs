using System;

namespace ScoreFight.Domain.Matches.Queries
{
    public class GetMatchByIdQuery : IQuery<Match>
    {
        public GetMatchByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
