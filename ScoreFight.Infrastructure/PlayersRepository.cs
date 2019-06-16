using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Player> Query(Func<IQueryable<Player>, IEnumerable<Player>> query)
            => query(_efContext.Players);

        public Player GetById(Guid id)
            => _efContext.Players.Find(id);

        public void Update(Player player)
        {
            _efContext.Players.Update(player);
            _efContext.SaveChanges();
        }
    }
}
