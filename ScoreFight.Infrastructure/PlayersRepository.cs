using System;
using ScoreFight.Domain.Players;

namespace ScoreFight.Infrastructure
{
    internal class PlayersRepository : IPlayersRepository
    {
        private readonly EfContext _efContext;

        public PlayersRepository(EfContext efContext)
        {
            _efContext = efContext;
        }

        public Player GetById(Guid id)
            => _efContext.Players.Find(id);
    }
}
