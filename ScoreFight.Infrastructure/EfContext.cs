using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScoreFight.Domain;
using ScoreFight.Domain.Bets;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;
using ScoreFight.Infrastructure.EntityConfiguration;

namespace ScoreFight.Infrastructure
{
    internal class EfContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("football");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BetConfiguration());

            modelBuilder.Entity<Team>().HasKey(x => x.Name);
            modelBuilder.Entity<Team>().HasData(TeamsInitialData());

            modelBuilder.Entity<Match>().HasKey(x => x.Id);
            modelBuilder.Entity<Match>().HasData(MatchesInitialData());

            modelBuilder.Entity<Player>().HasKey(x => x.Id);
            modelBuilder.Entity<Player>().HasData(PlayersInitialData());
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

        private static IEnumerable<Player> PlayersInitialData()
        {
            var myId = Guid.Parse("C9888D13-E9DA-454A-86A2-62BEC0302F2D");
            var playerLogins = new[] { "Dawid", "Miłosz", "Arkadiusz", "Janusz", "Bartłomiej", "Łukasz", "Henryk", "Izabella", "Rafał", "Kamila" };
            var random = new Random();

            for (var i = 0; i < 10; i++)
            {
                var id = i == 0 ? myId : Guid.NewGuid();
                var level = random.Next(1, 15);
                var wins = random.Next(1, 40);
                var loses = random.Next(5, 60);

                var player = new Player
                {
                    Id = id,
                    Login = playerLogins[i],
                    Level = level,
                    MaxLevel = level + 5,
                    Wins = wins,
                    Loses = loses,
                    Points = (wins * 10) - (loses * 3)
                };

                yield return player;
            }
        }
    }
}
