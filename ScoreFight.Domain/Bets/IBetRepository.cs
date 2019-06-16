using System;
using System.Collections.Generic;

namespace ScoreFight.Domain.Bets
{
    public interface IBetRepository
    {
        Bet GetPlayerBet(Guid playerId, Guid matchId);

        ICollection<Bet> GetBetsByMatchId(Guid matchId);

        ICollection<Bet> GetBetsByPlayerId(Guid playerId);

        void Add(Bet bet);

        void Update(Bet bet);

        void Remove(Bet bet);
    }
}
