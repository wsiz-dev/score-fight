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

        public Bet GetBet(Guid userid, Guid matchId)
        {
            return _context.Bets.FirstOrDefault(x => x.UserId == userid && x.MatchId == matchId);
        }

        public bool Exist(Guid userid, Guid matchId)
        {
            return _context.Bets.Any(x => x.UserId == userid && x.MatchId == matchId);
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