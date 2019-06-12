using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return _context.Bets
                .Where(x => x.PlayerId == playerId && x.MatchId == matchId)
                .Include(x => x.Matches)
                .FirstOrDefault();
        }

        public bool Exist(Guid playerId, Guid matchId)
        {
            return _context.Bets.Any(x => x.PlayerId == playerId && x.MatchId == matchId);
        }

        public void Save(Bet bet)
        {
            _context.Bets.Add(bet);
            Commit();
        }

        public void Cancel(Bet bet)
        {
            _context.Bets.Remove(bet);
            Commit();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}