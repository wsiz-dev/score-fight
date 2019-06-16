using System;
using System.Collections;
using System.Collections.Generic;
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

        public Bet GetPlayerBet(Guid playerId, Guid matchId)
        {
            return _context.Bets
                .Where(x => x.PlayerId == playerId && x.MatchId == matchId)
                .Include(x => x.Match)
                .Include(x => x.Player)
                .FirstOrDefault();
        }

        public ICollection<Bet> GetBetsByMatchId(Guid matchId)
        {
            return _context.Bets
                .Where(x => x.MatchId == matchId)
                .Include(x => x.Player)
                .ToList();
        }

        public ICollection<Bet> GetBetsByPlayerId(Guid playerId)
        {
            return _context.Bets
                .Where(x => x.PlayerId == playerId)
                .Include(x => x.Player)
                .ToList();
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