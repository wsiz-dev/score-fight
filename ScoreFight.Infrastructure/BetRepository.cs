﻿using System;
using System.Collections.Generic;
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

        public Bet GetPlayerBet(Guid playerId, Guid matchId)
        {
            return _context.Bets
                .FirstOrDefault(x => x.PlayerId == playerId && x.MatchId == matchId);
        }

        public ICollection<Bet> GetBetsByMatchId(Guid matchId)
        {
            return _context.Bets
                .Where(x => x.MatchId == matchId)
                .ToList();
        }

        public ICollection<Bet> GetBetsByPlayerId(Guid playerId)
        {
            return _context.Bets
                .Where(x => x.PlayerId == playerId)
                .ToList();
        }

        public void Add(Bet bet)
        {
            _context.Bets.Add(bet);
            _context.SaveChanges();
        }

        public void Update(Bet bet)
        {
            _context.Bets.Update(bet);
            _context.SaveChanges();
        }

        public void Remove(Bet bet)
        {
            _context.Bets.Remove(bet);
            _context.SaveChanges();
        }
    }
}