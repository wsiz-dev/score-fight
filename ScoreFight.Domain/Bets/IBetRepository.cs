using System;

namespace ScoreFight.Domain.Bets
{
    public interface IBetRepository
    {
        Bet GetBet(Guid playerId, Guid matchId);

        bool Exist(Guid playerId, Guid matchId);

        void Save(Bet bet);
        void Commit();
    }
}
