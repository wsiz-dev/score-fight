using System;
using System.Collections;
using System.Collections.Generic;

namespace ScoreFight.Domain.Bets
{
    public interface IBetRepository
    {
        Bet GetPlayerBet(Guid playerId, Guid matchId);

        ICollection<Bet> GetBetsByMatchId(Guid matchId);

        ICollection<Bet> GetBetsByPlayerId(Guid playerId);

        bool Exist(Guid playerId, Guid matchId);

        void Save(Bet bet);

        void Cancel(Bet bet);

        void Commit();
    }
}
