using System;

namespace ScoreFight.Domain.Bets
{
    public interface IBetRepository
    {
        Bet GetBet(Guid userId, Guid matchId);

        bool Exist(Guid userId, Guid matchId);

        void Save(Bet bet);
        void Commit();
    }
}
