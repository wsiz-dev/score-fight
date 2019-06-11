using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScoreFight.Domain;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Infrastructure
{
    internal class EfContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("football");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>().HasKey(x => x.Name);
            modelBuilder.Entity<Team>().HasData(TeamsInitialData());

            modelBuilder.Entity<Match>().HasKey(x => x.Id);
            modelBuilder.Entity<Match>().HasData(MatchesInitialData());
        }

        private static IEnumerable<Team> TeamsInitialData()
        {
            var teamNames = new [] { "Bayern", "Borussia", "Eintracht", "Schalke", "Bayer", "Hertha", "Leipizg", "Hoffenheim", "Stuttgart", "Wolfsburg" };
            var random = new Random();

            for (var i = 0; i < 10; i++)
            {
                var team = new Team(teamNames[i]);
                for (var j = 0; j < 8; j++)
                {
                    team.InsertResult(random.Next(0, 5), random.Next(0, 5));
                }

                yield return team;
            }
        }

        private static IEnumerable<Match> MatchesInitialData()
        {
            var now = DateTime.Now;
            var today = new DateTime(now.Year, now.Month, now.Day, 20, 0, 0);

            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "Not active match", AwayTeam = "Should not display", Date = today.AddDays(-1) };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "Liverpool", AwayTeam = "Manchester City", Date = today };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "Chelsea", AwayTeam = "Manchester United", Date = today };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "AS Roma", AwayTeam = "Napoli", Date = today.AddDays(1) };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "Inter Mediolan", AwayTeam = "AC Milan", Date = today.AddDays(1) };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "Bayern Monachium", AwayTeam = "Borussia Dortmund", Date = today.AddDays(2) };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "Bayer Leverkusen", AwayTeam = "Schalke 04", Date = today.AddDays(2) };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "Legia Warszawa", AwayTeam = "Lech Poznań", Date = today.AddDays(3) };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "Śląsk Wrocław", AwayTeam = "Wisła Kraków", Date = today.AddDays(3) };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "FC Barcelona", AwayTeam = "Real Madryt", Date = today.AddDays(4) };
            yield return new Match { Id = Guid.NewGuid(), HomeTeam = "Atletico Madryt", AwayTeam = "Valencia", Date = today.AddDays(4) };
        }
    }
}
