using System;

namespace ScoreFight.Domain
{
    public class MatchResult
    {
        private bool _resultApplied;

        public Team HomeTeam { get; }
        public int HomeTeamGoals { get; }

        public Team AwayTeam { get; }
        public int AwayTeamGoals { get; }

        public MatchResult(Team homeTeam, int homeTeamGoals, Team awayTeam, int awayTeamGoals)
        {
            HomeTeam = homeTeam;
            HomeTeamGoals = homeTeamGoals;
            AwayTeam = awayTeam;
            AwayTeamGoals = awayTeamGoals;
            _resultApplied = false;
        }

        public void ApplyResult(Team homeTeam, Team awayTeam)
        {
            if (_resultApplied)
            {
                throw new InvalidOperationException("Match result is already applied.");
            }

            homeTeam.InsertResult(HomeTeamGoals, AwayTeamGoals);
            awayTeam.InsertResult(AwayTeamGoals, HomeTeamGoals);
            _resultApplied = true;
        }
    }
}
