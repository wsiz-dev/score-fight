using System;
using System.Linq;
using ScoreFight.Domain.Bets;

namespace ScoreFight.Infrastructure
{
    internal class BetRepository : IBetRepository
    {
        private readonly EfContext _context;

        public BetRepository(EfContext context)
        {
            _context = context;
        }

        public Bet GetBet(Guid playerId, Guid matchId)
        {
            return _context.Bets.FirstOrDefault(x => x.PlayerId == playerId && x.MatchId == matchId);
        }

        public bool Exist(Guid playerId, Guid matchId)
        {
            return _context.Bets.Any(x => x.PlayerId == playerId && x.MatchId == matchId);
        }

        public void Save(Bet bet)
        {
            _context.Add(bet);
            Commit();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}