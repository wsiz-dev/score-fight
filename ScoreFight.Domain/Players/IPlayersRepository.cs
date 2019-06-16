using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreFight.Domain.Players
{
    public interface IPlayersRepository
    {
        IEnumerable<Player> Query(Func<IQueryable<Player>, IEnumerable<Player>> query);

        Player GetById(Guid id);

        void Update(Player player);
    }
}
