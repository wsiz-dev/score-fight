using System;

namespace ScoreFight.Domain.Bets.Command
{
    public class SetBetCommand : ICommand
    {
        public string UserId { get; }

        public string MatchId { get; }

        public int TeamBet { get; }

        public int PointsBet { get; }


        public SetBetCommand(string userId, string matchId, int teamBet, int pointsBet)
        {
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentException(nameof(userId));
            UserId = userId;

            if (string.IsNullOrWhiteSpace(matchId)) throw new ArgumentException(nameof(matchId));
            MatchId = matchId;

            if (teamBet < 0) throw new ArgumentException(nameof(teamBet));
            TeamBet = teamBet;

            if (pointsBet < 0) throw new ArgumentException(nameof(pointsBet));
            PointsBet = pointsBet;  
        }
    }
}
