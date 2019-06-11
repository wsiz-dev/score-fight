using System;
using System.Collections.Generic;
using System.Linq;
using ScoreFight.Domain;

namespace ScoreFight.Infrastructure
{
    internal class FootballRepository : IFootballRepository
    {
        private readonly EfContext _context;

        public FootballRepository(EfContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> Query(Func<IQueryable<Team>, IQueryable<Team>> query)
            => query(_context.Teams);

        public Team GetTeam(string name)
            => _context.Teams.Find(name);

        public void Save(MatchResult matchResult)
        {
            _context.Teams.Update(matchResult.HomeTeam);
            _context.Teams.Update(matchResult.AwayTeam);
            _context.SaveChanges();
        }
    }
}
