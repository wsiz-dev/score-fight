using System;

namespace ScoreFight.Domain.Players
{
    public class GetPlayerByIdQuery : IQuery<Player>
    {
        public GetPlayerByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
