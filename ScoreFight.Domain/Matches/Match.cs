using System;

namespace ScoreFight.Domain.Matches
{
    public class Match
    {
        public Guid Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public DateTime Date { get; set; }

        public MatchResults? Result { get; set; }
    }
}
