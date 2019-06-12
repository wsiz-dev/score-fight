using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreFight.Domain.Matches
{
    public interface IMatchesRepository
    {
        IEnumerable<Match> Query(Func<IQueryable<Match>, IEnumerable<Match>> query);

        Match GetById(Guid matchId);
    }
}
