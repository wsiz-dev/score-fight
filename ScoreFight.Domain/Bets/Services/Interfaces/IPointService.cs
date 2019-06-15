using System.Collections.Generic;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Bets.Services.Interfaces
{
    public interface IPointService
    {
        void CountPointsAfterMatch(ICollection<Bet> bets, MatchResults result);
    }
}
