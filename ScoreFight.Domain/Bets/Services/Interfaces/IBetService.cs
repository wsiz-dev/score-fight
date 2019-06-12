using System;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Bets.Services.Interfaces
{
    public interface  IBetService
    {
        void CheckIfBetAlreadyExist(Guid userId, Guid matchId);

        void CheckIfMatchDoesNotExist(Match match, string matchId);

        void CheckIfMatchAlreadyStarted(Match match);

    }
}
